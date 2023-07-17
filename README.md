# EAVR-DEMO-DDW

Eindhoven Acoustic VR (EAVR) DEMO DDW is an interactive audio-visual VR demonstration designed by the researchers of the Building Acoustics Group at Eindhoven University of Technology. The demonstration was presented at the Dutch Design Week (DDW) exhibition in 2019 as “Listen to your own voice in VR”. The goal of this demonstration was to provide listeners' an experience as to how their voice sounds in two different virtual environment. 

## Requirements

### Hardware
The demonstration has been tested with Oculus Rift S and Oculus Quest headset. Additionally, it is highly recommended to use external headphones and an audio interface.

### Software  

* [Unity 2019.4.36f1](https://unity.com/releases/editor/qa/lts-releases?version=2019.4) - LTS Version.
* [Max/MSP](https://cycling74.com/releases/max/8.5.0)
* Required packages in Max: Max-SDK and Sadam Library (Max external objects for UDP communication). These can be installed from the Max package manager. 
 * [CUDA Toolkit 10.0](https://developer.nvidia.com/cuda-10.0-download-archive?target_os=Windows&target_arch=x86_64&target_version=10&target_type=exelocal)


 ## Repository contents 

 1. Unity Project - unity-EAVR-DEMO-DDW

 2. Audio Engine in Max/MSP in the folder audio-Max. The audio-max folder has two subfolders audio_material and prerequisites.

 The audio-material folder contains the following:

 * audio-EAVR-DEM-DDW.maxpat – Patch for running the demo using Max/MSP. 
  * dynconvgpu~. mxe64 - Max external object for performing dynamic convolution.
  * Two folders (.zip files) Binaural Room Impulse Responses (BRIRs) of two room acoustic scenarios - Sports Hall brirs_sports_hall and Reverberation Hall brirs_reverberation_room. Each folder contains a total of 144 files in .txt format. Each of the 72 files corresponds to left or right channel of the BRIR. The file naming convention is BRIR_angle_l_1.txt and BRIR_angle_r_1.txt, where l means “Left ear” and r stands for “Right ear”. 

The prerequisite folder contains the following:

 * [fftw3 library](https://github.com/FFTW/fftw3) – A collection of fast C routines for computing the Discrete Fourier Transform in one or more dimensions.  
 * cppIntegration.dll – A DLL file for CUDA kernels. Integrating CUDA into an existing C++ application.  
                                                                                     
## Setup and Running the demonstration

Download or clone the repository.  

## Settings for Max

1. Open audio-EAVR-DEM-DDW.maxpat Max patch from the audio-Max folder.


### Settings

2. On the Max Patch. Go to File --> Show Package Manager. Install Sadam Library and Max SDk. 
3. Go to Options --> File Preferences. Check the paths for the relevant files.
4. Go to Options --> Audio Status. Set the audio driver, input driver and output device. The sampling rate should be set as 48000 Hz.
5.  Set the paths for the BRIR folders and cppIntegration.dll respectively, as follows

C:/Users/../../../brir_reverberation_room/

C:/Users/../../../brir_sports_hall/

C:/Users/../../../prerequisites/


## For Unity

1. Open the unity-EAVR-DEMO-DDW Project with Unity 2019.4.36f1 version.
2.  Press the play button. The instructions on how to use the demonstration are visible and guide the user to proceed ahead.
3. The demonstration has been configured for the primary buttons "X" on the left and "A" on the right touch controller. 

  



