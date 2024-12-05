using NUnit.Framework;
using AltTester.AltTesterUnitySDK.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Tests
{
    private AltDriver altDriver;

    // Common XPath constants
    private const string ShopButtonXPath = "//menu__shop-button";
    private const string HomeButtonXPath = "//menu__home-button";
    private const string GoldCountXPath = "//options-bar__gold-count";
    private const string GemCountXPath = "//options-bar__gem-count";
    private const string PlayButtonXPath = "//home-play__level-button";
    private const string PauseButtonXPath = "//pause__button-container";
    private const string ResumeButtonXPath = "//pause__resume-button";
    private const string CharButtonXPath = "//menu__char-button";
    private const string BuyButtonXPath = "//shop-item__buy-button";

    // Set up AltDriver before any test runs
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver = new AltDriver();
    }

    // Tear down the AltDriver after all tests
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        altDriver.Stop();
    }
    [TearDown]
    public void TearDown()
    {
        ClickButton(HomeButtonXPath);
    }



    // Tests
    [Test]
    public void TestGetCoinsFree()
    {
        ClickButton(ShopButtonXPath);

        var initialGold = int.Parse(GetText(GoldCountXPath));
        ClickButton(BuyButtonXPath);
        Thread.Sleep(1000);

        var finalGold = int.Parse(GetText(GoldCountXPath));
        Assert.That(finalGold, Is.EqualTo(initialGold + 50));
    }

    [Test]
    public void TestBuyGems()
    {
        var initialGems = int.Parse(GetText(GemCountXPath));
        ClickButton(ShopButtonXPath);
        ClickButton("//shop-gem-shoptab");
        ClickButton(BuyButtonXPath);
        Thread.Sleep(1000);

        ClickButton("//shop-gold-shoptab");

        var finalGems = int.Parse(GetText(GemCountXPath));
        Assert.That(finalGems, Is.EqualTo(initialGems + 10));
    }

    [Test]
    public void TestBuyCoinsWithInsufficientGems()
    {
        ResetPlayerCurrency();

        ClickButton(ShopButtonXPath);
        var initialGold = GetText(GoldCountXPath);

        ClickButton("//UnityEngine.UIElements.TemplateContainer[1]" + BuyButtonXPath);
        var finalGold = GetText(GoldCountXPath);


        Assert.That(finalGold, Is.EqualTo(initialGold));
    }

    [Test]
    public void TestPlay()
    {
        ClickButton(PlayButtonXPath);
        Thread.Sleep(1000);

        ClickButton(PauseButtonXPath);
        ClickButton(ResumeButtonXPath);
        Thread.Sleep(1000);

        ClickButton(PauseButtonXPath);
        ClickButton("//pause__quit-button");
    }

    [Test]
    public void TestEquipItem()
    {
        ClickButton(CharButtonXPath);
        ClickButton("//char__unequip-button");
        CheckInventorySlotsEnabled();
        ClickButton("//char-inventory__slot1-add");
        ClickButton("//gear-item__icon");
        ClickButton("//inventory__back-button-icon");
        WaitForElementNotPresent("//char-inventory__slot1-add");

    }

    [Test]
    public void TestAutoEquip()
    {
        ClickButton(CharButtonXPath);
        ClickButton("//char__unequip-button");

        bool allSlotsEnabled = CheckInventorySlotsEnabled();
        ClickButton("//char__auto-equip-button");
        Thread.Sleep(1000);

        WaitForElementNotPresent("//char-inventory__slot1-add");
        WaitForElementNotPresent("//char-inventory__slot2-add");
        WaitForElementNotPresent("//char-inventory__slot3-add");
        WaitForElementNotPresent("//char-inventory__slot4-add");
        Assert.True(allSlotsEnabled);
    }

    [Test]
    public void TestGoThroughEveryCharacter()
    {
        var expectedCharacters = new List<string> { "Sir Jarek", "Wolfman Oriz", "Witch Giorgia", "The Necromancer" };
        var charList = new List<string>();

        ClickButton(CharButtonXPath);

        for (int i = 0; i < expectedCharacters.Count; i++)
        {
            charList.Add(GetText("//char__label"));
            ClickButton("//char__next-button");
        }

        bool allCharactersPresent = expectedCharacters.All(charList.Contains);
        Assert.That(allCharactersPresent, Is.True);
    }

    [Test]
    public void TestGoThroughEveryMenuPanel()
    {
        ClickButton(CharButtonXPath);
        ClickButton("//menu__info-button");
        ClickButton(ShopButtonXPath);
        ClickButton("//menu__mail-button");
        ClickButton(HomeButtonXPath);
    }

    // Helper functions
    private void ResetPlayerCurrency()
    {
        ClickButton("//safe-area/OptionsBar/options-bar/options-bar__button");
        ClickButton("//settings__account/settings__social-button2");
        ClickButton("//settings__panel-back-button");
        Thread.Sleep(1000);
    }

    private bool CheckInventorySlotsEnabled()
    {
        var slot1 = altDriver.WaitForObject(By.PATH, "//char-inventory__slot1-add", enabled: false);
        var slot2 = altDriver.WaitForObject(By.PATH, "//char-inventory__slot2-add", enabled: false);
        var slot3 = altDriver.WaitForObject(By.PATH, "//char-inventory__slot3-add", enabled: false);
        var slot4 = altDriver.WaitForObject(By.PATH, "//char-inventory__slot4-add", enabled: false);

        return slot1.enabled && slot2.enabled && slot3.enabled && slot4.enabled;
    }
    private void ClickButton(string xpath)
    {
        var button = altDriver.WaitForObject(By.PATH, xpath);
        altDriver.Click(button.GetScreenPosition());
    }

    private string GetText(string xpath)
    {
        return altDriver.WaitForObject(By.PATH, xpath).GetText();
    }

    private void WaitForElementNotPresent(string xpath)
    {
        altDriver.WaitForObjectNotBePresent(By.PATH, xpath);
    }
}
