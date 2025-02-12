# DragonCrasher Example Project

This repository contains an example project designed to demonstrate how to write and run automated tests using **AltTester®** in a Unity project that utilizes **UI Toolkit**.

## Overview

The example includes pre-written tests to showcase how AltTester® can be used to interact with Unity UI elements and validate behaviors. To run these tests, you need to prepare a standalone build of the example project and have **AltTester® Desktop** running.

## Prerequisites

1. **Unity Editor**: Install the Unity Editor. Version compatibility depends on the example project.
2. **AltTester®**: Download AltTester® from the provided link.
3. **.NET SDK**: Ensure you have the .NET SDK installed to run the tests (`dotnet test`).

## Setup Instructions

Follow these steps to get started:

### 1. Create a Unity Project
- Open Unity Hub and create a new Unity project using your preferred template.

### 2. Download the Example Project
- Download the example project from [Example Project Link](https://assetstore.unity.com/packages/essentials/tutorial-projects/dragon-crashers-urp-2d-sample-project-190721?srsltid=AfmBOop2dsRrp8mm-6vaDpipAyQ3tr24VFvKU5_SdHiJD0QUudcYgT2M) and import it into your Unity project.

### 3. Import AltTester® package in Unity Editor
- Download AltTester® from [AltTester® Download Link](https://alttester.com/app/uploads/AltTester/sdks/AltTesterUnitySDK_NonGPL_2_2_2.unitypackage).
- Follow the setup instructions in the [AltTester® Documentation](https://altTester.com/docs/sdk/latest/pages/get-started.html#import-altTester-package-in-unity-editor).

### 4. Build the Standalone Game
- Name the build **DragonCrasher**.
- Build the project following the instructions in the [AltTester® Documentation](https://alttester.com/docs/sdk/latest/pages/get-started.html#instrument-your-app-with-alttester-unity-sdk).

### 5. Set Up AltTester® Desktop
- Download and install **AltTester® Desktop** from [Mac](https://alttester.com/app/uploads/AltTester/desktop/AltTesterDesktop__v2.2.3.dmg) or [Windows](https://alttester.com/app/uploads/AltTester/desktop/AltTesterDesktop__v2.2.3.exe).
## Running the Tests

Once the setup is complete, follow these steps to run the tests:

1. Open the standalone build (**DragonCrasher**).
2. Launch **AltTester® Desktop**.
3. Navigate to the `Tests` folder in this repository using a terminal or command prompt.
4. Run the following command:
   ```bash
   dotnet test
   ```

The tests will connect to the running game and execute automatically.

## Support
If you encounter any issues, consult the [AltTester® Documentation](https://altTester.com/docs/sdk/latest/index.html) or reach out to the [Discord channel](https://discord.gg/Ag9RSuS).

Happy Testing! 🚀
