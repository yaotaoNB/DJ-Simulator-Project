using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DJ_Audio_Process : MonoBehaviour {

	public CsoundUnity dj_Process;
	public AudioSource mySource;
	float[] samples = new float[16384];
	public int blockSize, channel;
	int preBlockSize;
	int block, blockleft;
	void setUp(){
		channel = 2;
	}

	void Process_Audio(){
		if (blockSize != preBlockSize) {
			Array.Resize<float> (ref samples,blockSize);
		}
		if (mySource.isPlaying) {
			mySource.GetOutputData (samples, 0);
			dj_Process.processBlock (samples, channel);
		}
		preBlockSize = blockSize;
	}
}
