/*

2. tempscal only read mono? (GEN01) what should I do with my stereo sound files? ftgentmp GEN01 last argument channel number to read?
3. Windows says Csound lost .dll
7. How to use C++ .dylib in Unity?

 * /
/*
Other features:
CDJ停止时drag不平稳会改变pitch（像惯性一样）。

2. Can choose song list through ingame GUI, short cut computer keyboard to load tracks to L/R dect.
3. Can display timedomain of audio (Output from AudioSource), modify the freq domai, 16 FFT bands for each deck, delete 512 bands.
4. Detect BPM, can scale the timescale number to BPM.
5. Can jump into different sections of songs through Cue points, can save the cue point data of songs, cue points can be triggered through 1-0 hot keys.
6. EQ knobs, loop functions of CDJ.
7. iPad controller.(可选：replace the CsoundUnity with .dylib)
8. First person controller interact with the CDJ, replace the model of CDJ., entire club scene, player can walk around.
9. Build MMO network.
10. VR controller, add more visual effects.
11. Add more effect, knobs and functions to the CDJ.

Next step:
	1. Try change fft size through script, CDJ keep rolling problem.
	2. Keep asking build relative path problem.
	3. Time domain display optimization (only once) and array length.
	4. build GUI to manipulate song to play, bpm and pitch.
	5. model.
	6. tap tempo

Import Windows Doc:
			1. import Windows package (only dll), you don't need to install Csound
			2. Use a relative path "AudioPath" in windows
			3. Make sure smaple rate in both Unity audio project setting and Windows output device are 44.1kHz, .csd is 48000Hz
		

*/
/*
	Can you briefly explain how to build a library with C++ and use it to manipulate output from the AudioSource? How to make C++/dll works with C# in Unity.
	1. L/R scratching beat lag problem, use Test.ogg to try (Try 2 audio sources)
	2. How to reset the start time in Csound?
	3. How to deal with the lag time if initialize NEW_FILE?
	4. array size of GetOutputData() problem.
	6. Unity quit problem.
	7. When I change pitch/timescale, the low end is really unstable sometime lost.
	8. Is that possible to make a VST/AU plugIn and use it in Unity?

	I. Where can I find tutorial talks about audio engine API for different engines?

	Nikil:
	1. the opcode to timestretch with stream
	2. master clock/phasor problem
	3. if processing audio is not working, how to loop an audio in Csound? Switch table really quick without delay?
	
*/