# Overview
Nature Quest is an educational mobile game that aims to encourage children (k-8) to explore the UCI Ecological Preserve interactively. It introduces engaging minigames, cute “Sprout” characters and fun rewards to make learning about nature interesting and accessible for younger users. The project was built using Unity game engine and developed for Android devices. 

## Purpose
Nature Quest was created to make outdoor education engaging for young visitors. By combining real world exploration with short mobile mini-games, the project helps children learn about local plants and animals while visiting the UCI Ecological Preserve.

## Features
- Geolocation-based exploration tied to the UCI Ecological Preserve
- Educational mini-games designed to teach ecological concepts
- Interactive UI with AR-style map navigation (via Mapbox)
- Progress tracking for completed activities and learning modules

## Target Platforms 
- Android mobile
  - Minimum API Level: Android 7.0 'Nougat' (API level 24)
  - Target API Level: Android 14.0 (API level 34)   

# Project Structure
```
Nature-Quest/
├── .vscode/
├── Assets/
│   ├── Editor/
│   ├── Prefabs/
│   ├── Resources/
│       ├── components/
│           ├── Custom/
│   ├── Scenes
│   └── Scripts
├── Packages/
├── ProjectSettings/
├── .gitattributes
├── .gitignore
├── vsconfig
└── README.md 
```
# Project Setup

## Development Environment
- Unity Editor 2022.2.55f1
- Mapbox Unity SDK (v2.1.1 or newer)
- Android Build Support (via Unity Hub)
  
## Installation
Follow these steps to set up the project in the Unity editor.

### 1. Cloning this repository
```
bash
git clone https://github.com/YOUR_ORG/Nature-Quest.git
```
To clone the project simply select "Code" drop down on the github repository page and then clone the project using HTTPS, SSH, or GitHub CLI. 
You can also clone via SSH if preferred.

### 2. Install Unity 2022.2.55f1
1. Download and install **Unity Hub** from [unity.com/download](https://unity.com/download).
2. In **Unity Hub**, open the **Installs** tab and choose **Install Editor**.
3. Select version **2022.2.55f1** and make sure **Android Build Support** is checked.

### 3. Add the project to Unity Hub
In the **Projects** tab click **Add** and browse to the folder where the repository was cloned.

### 4. Configure Mapbox
1. Sign up for a free Mapbox account and create an access token in the Mapbox console.
2. Open the project in Unity and choose **Mapbox > Setup** from the menu.
3. Paste your token into the **Access Token** field and click **Submit**.

## Building and Running
1. Connect an Android device with Developer Mode enabled.
2. In Unity, go to `File > Build Settings`.
3. Select `Android` and click `Switch Platform`.
4. Click `Build and Run`.

## Known Issues
- UI responsive layout
  - Alignment and scale issues on certain devices 
- Android the only supported mobile platform 
- Map interactions clunky 
  - Pinch and zoom, accident clicks
- Game play testing
  - Do users understand how to play the mini-games?

- Camera does not always stay centered on player (Mapbox sync issue)

## TODO
- Admin portal 
  - Park staff sets mini game location and lesson details
  - Access collected data
  - Set up backend database for storing collected data
- More mini-games with more variation
  - Highlight more plant and bird species
  - Sprout Village AR mini-game
- More custom game assets
  - Player pawn, site markers, game map
  - Game audio 
  - Animation 
- User authentication and management
- Expand to more UCI Nature preserve sites

## Security Note
Do **not** commit API keys or sensitive data directly in the project files.
Use environment variables or Unity's `Resources` folder with `.gitignore` in place to prevent exposure.

# Contributors
## Team Members
- Armon Amini | Developer
- Brandon Smith | UI/UX
- Giovanna Mancinelli | UI/UX
- Matthew Duong | Developer
- Susaanah Liu | Developer
- Zachary Thomas | Developer

## Project Sponsors
- UCI Nature
  - Megan Lulow, Ph.D
  - Julie Coffey, M.sc
  - Thanh Le
  - Moises Perea-Vega
- Matthew Bietz Ph.D     
