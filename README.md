# unity-volume-slider

## Description
This is a component for the slider that sets the volume of AudioMixer.

## How to use
At the Audio Mixer...

- Create 'Audio Mixer' if you don't have

![screenshot](https://github.com/neuneu9/unity-volume-slider/blob/images/create_audio_mixer.png)

- Expose any group's 'Volume' parameter

![screenshot](https://github.com/neuneu9/unity-volume-slider/blob/images/expose_volume.png)

- Rename the parameter

![screenshot](https://github.com/neuneu9/unity-volume-slider/blob/images/rename_parameter.png)

At the scene...

- Create 'Slider'
- Add this component (VolumeSlider.cs)
- Drop the Audio Mixer and input the parameter name in Inspector

![screenshot](https://github.com/neuneu9/unity-volume-slider/blob/images/inspector_setup.png)

*Don't forget to set group at your AudioSource!

![screenshot](https://github.com/neuneu9/unity-volume-slider/blob/images/audio_source.png)
