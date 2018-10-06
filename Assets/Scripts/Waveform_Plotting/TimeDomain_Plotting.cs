using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimeDomain_Plotting : MonoBehaviour {

	public LineRenderer lineRend;
	public int sampleSize = 4096;
	int presampleSize;
	[SerializeField]
	float len = 25f;
	[SerializeField]
	float amp = 20f;
	public AudioSource source;
	float[] samples = new float[4096];
	//int clipLength;

	void Awake(){
		lineRend.positionCount = sampleSize;
	}

	void waveform_Plotting(){
		if (sampleSize != presampleSize) {
			Array.Resize<float> (ref samples,sampleSize);
			lineRend.positionCount = sampleSize;
		}
		if (source.isPlaying) {
			source.GetOutputData (samples,0);
			for (int i = -sampleSize / 2; i < sampleSize / 2; i++) {
				lineRend.SetPosition(i+sampleSize/2,new Vector3(i*(float)((float)len/(float)sampleSize),samples[i+sampleSize/2]*amp,0f));
			}
		}
		presampleSize = sampleSize;
	}

	void Update () {
		waveform_Plotting ();
	}
}
