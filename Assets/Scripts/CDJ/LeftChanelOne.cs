using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (AudioSource))]
public class LeftChanelOne : MonoBehaviour {
	AudioSource audioSourceLeft;
	public static float [] _samplesLeft = new float[512];
	public static float[] _freqBand = new float[8];
	//everytime the freqband is higher than the band buffer, the band buffer become the freqband, if freqband is lower than the band buffer, the band buffer decrease.
	public static float[] _bandBuffer = new float[8];
	float[] _bufferDecrease = new float[8];

	float[] _freqBandHighest = new float[8];
	public static float[] _audioBand = new float[8];
	public static float[] _audioBandBuffer = new float[8];


	void Start(){
		audioSourceLeft = GetComponent<AudioSource> ();
	}

	void Update () {
		GetComponent<AudioSource> ().volume = Vol_Fader.volumeL * CrossFader.leftVol;
		GetSpectrumAudioSource ();
		MakeFrequencyBands ();
		BandBuffer ();
		CreateAudioBands ();
		//print (_audioBandBuffer[1]);
	}
	void CreateAudioBands(){
		for(int i = 0; i<8; i++){
			if (_freqBand [i] > _freqBandHighest [i]) {
				_freqBandHighest [i] = _freqBand [i];
			}
			_audioBand [i] = (_freqBand [i] / _freqBandHighest [i]);
			_audioBandBuffer [i] = (_bandBuffer [i] / _freqBandHighest [i]);
		}
	}

	void GetSpectrumAudioSource(){
		audioSourceLeft.GetSpectrumData (_samplesLeft,0,FFTWindow.Blackman);

	}

	void BandBuffer(){
		for (int g = 0; g < 8; ++g) {
			if (_freqBand [g] > _bandBuffer [g]) {
				_bandBuffer [g] = _freqBand [g];
				//if freqBand is higher than the previous frame, the number it decrease will be smaller
				_bufferDecrease [g] = 0.03f;//0.005f
			}
			if (_freqBand [g] < _bandBuffer [g]) {
				_bandBuffer[g] -= _bufferDecrease [g];
				//if freqBand is lower than the previous frame, the number it decrease will be bigger and faster in order to catch up the previous frame
				_bufferDecrease [g] *= 1.2f;//1.2f
			}
		}

	}

	void MakeFrequencyBands(){
		/*
		 22050(the Nyquist freq of 441kHz)/512 windows =  43Hz per band
		 devided into 8 bands
		 0 -> 2 windows = 86 Hz
		 1 -> 4 windows = 172Hz (87-258)
		 2 -> 8 windows = 344Hz (259 - 602)
		 3 -> 16 windows = 688Hz (603 - 1290)
		 4 -> 32 windows = 1376Hz (1291 - 2666)
		 5 -> 64 windows = 2752Hz (2667 - 5418)
		 6 -> 128 windows = 5504Hz (5419 - 10922)
		 7 -> 256 = windows = 11008Hz (10923 - 21930)
		 510
		 */
		int count = 0;
		for (int i = 0; i < 8; i++) {
			float average = 0;
			int sampleCount = (int)Mathf.Pow (2, i) * 2;
			if (i == 7) {
				sampleCount += 2;
			}
			for(int j = 0;j<sampleCount;j++){
				average += _samplesLeft [count] * (count + 1);
					count++;
			}
			average /= count;
			_freqBand [i] = average * 10;
		}
	}
}
