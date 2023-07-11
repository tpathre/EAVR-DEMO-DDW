# EAVR-DEMO-DDW

Eindhoven Acoustic VR (EAVR) DEMO DDW is an interactive audio-visual VR demonstration designed by the researchers of the Building Acoustics Group at Eindhoven University of Technology. The demonstration was presented at the Dutch Design Week (DDW) exhibition in 2019 as “Listen to your own voice in VR”. The instructions on how to use the demonstration are given in the virtual environment. 

## Requirements

### Hardware
This demonstration has been tested with Oculus Rift S and Oculus Quest headset. It is highly recommended to use external headphones and an audio interface.

### Software  

[Unity 2019.4.36f1](https://unity.com/releases/editor/qa/lts-releases?version=2019.4) - LTS Version. 

[Max/MSP](https://cycling74.com/releases/max/8.5.0)

 [CUDA Toolkit 10.0](https://developer.nvidia.com/cuda-10.0-download-archive?target_os=Windows&target_arch=x86_64&target_version=10&target_type=exelocal)


 Required packages: Max-SDK and Sadam Library (Max external objects for UDP communication). These can be installed from the Max package manager. 

 ## Repository contents 

 1. Unity Project - unity-EAVR-DEMO-DDW.
 2. Audio engine in Max/MSP.


 * audio-EAVR-DEM-DDW.maxpat – Patch for running the demo using Max/MSP. 
  * dynconvgpu~. mxe64 - Max external object for performing dynamic convolution.
 * [fftw3 library](https://github.com/FFTW/fftw3) – A collection of fast C routines for computing the Discrete Fourier Transform in one or more dimensions.  
 * cppIntegration.dll – A DLL file for CUDA kernels. Integrating CUDA into an existing C++ application.  
 * Audio material - Binaural Room Impulse Responses (BRIRs) of two room acoustic scenarios - Sports Hall brirs_sports_hall and Reverberation Hall brirs_reverberation_room.

Each folder contains a total of 144 files in .txt format. Each of the 72 files corresponds to left or right channel of the BRIR. The file naming convention is BRIR_angle_l_1.txt and BRIR_angle_r_1.txt. where l means “Left ear” and r stands for “Right ear”. The BRIRs start from 1 to 72.

## How to run the demonstration?

Download repository. First open Max patch Unity project and Max patch. 

## For Max

1. Open audio-EAVR-DEM-DDW.maxpat Max patch from the audio-Max folder.
2. Go to File --> Show Package Manager. Install Sadam Library and Max sdk. 
3. Go to Options --> Audio Status. Set the audio driver, input device and output device. 
4. Add the paths for the BRIR folders and cppIntegration.dll.


## For Unity

1. Open Unity Project. 

  



