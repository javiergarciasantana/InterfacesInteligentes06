# InterfacesInteligentes06

# Speech Recognition and Interaction with Unity

This repository contains two Unity scripts demonstrating the integration of speech recognition using the HuggingFace API for interactive functionalities. Both examples showcase capturing audio via a microphone, processing it, and performing actions based on recognized speech.

## Features

- **SpeechRecognitionExample.cs**
  - Captures audio input using the Unity `Microphone` API.
  - Processes the audio into WAV format.
  - Sends the audio to HuggingFace's Automatic Speech Recognition API.
  - Displays transcribed text in the UI.

- **SpiderControllerWithSpeech.cs**
  - Controls a spider-like game object with voice commands.
  - Changes the material of the object or triggers animations based on recognized speech phrases.
  - Handles commands such as "Turn red", "Get to sleep", and "Wake up".

## Prerequisites

1. Unity version 2020.3 or higher.
2. [HuggingFace API](https://huggingface.co/) account and API key.
3. TextMeshPro installed in your Unity project.

## Setup

1. Clone this repository:
   ```bash
   git clone https://github.com/javiergarciasantana/InterfacesInteligentes06.git
   ```

2. Open the project in Unity.

3. Ensure the following dependencies are installed:
   - TextMeshPro
   - The `HuggingFace.API` package

4. Configure the HuggingFace API in your project:
   - Replace the placeholder `HuggingFaceAPI.AutomaticSpeechRecognition` with your implementation.

5. Attach the scripts to relevant GameObjects in your Unity scene.

## Script Descriptions

### `SpeechRecognitionExample.cs`
This script provides a simple UI for speech-to-text functionality:
- **Buttons**: Start and stop recording.
- **Audio Recording**: Captures audio using Unity's Microphone API.
- **Speech Recognition**: Sends the recorded audio to HuggingFace's API and updates a `TextMeshProUGUI` component with the response.

#### Usage
1. Attach this script to a GameObject in your scene.
2. Assign references for `startButton`, `stopButton`, and `TextMeshProUGUI` text components in the Inspector.
3. Run the scene, and use the buttons to start/stop recording.
![SpeechDemo](https://github.com/user-attachments/assets/7ac8f6b4-c83b-4f3d-a50f-ee8941c1794a)

### `SpiderControllerWithSpeech.cs`
This script demonstrates speech-based control of a spider object:
- **Audio Commands**:
  - "Turn red": Changes the object's material to red.
  - "Get to sleep": Triggers a death animation.
  - "Wake up": Resets the animation state.
- **Audio Recording and Processing**: Similar to the `SpeechRecognitionExample.cs`, records and processes audio input.

#### Usage
1. Attach this script to a spider GameObject.
2. Assign references for `InactiveMaterial`, `GazedAtMaterial`, `RedMaterial`, and the Animator in the Inspector.
3. Use voice commands while interacting with the object.

![SpeechArañaDemo2](https://github.com/user-attachments/assets/1729f9b0-3261-4d61-9143-219d4bb86393)

