using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMatch : MonoBehaviour {
	//Audio Interface: 0.46, Computer: 0.92
	public float originalbpm = 90f;
	public float bpmNow, pitchNow;
	float bpmToIncrease, bpmPre, pitchToIncrease, pitchPre;
	public CsoundUnity csoundunity;
	public string songToPlayLeft;
	public int checkTestString = 0;
	int checkForStringPre = 0;

	public float skipTime = 0f;
	//float skiptimePre = 0f;

	public string audioPaths;

	//testing before find the right Csound opcode solve audiosource problem
	public static float csoundPitchL = 1f;
	public static float csoundbpmL = 1f;

	void checkForString(){
		switch (checkTestString) {
		case 0:
			songToPlayLeft = "Symphony.ogg";
			break;
		case 1:
			songToPlayLeft = "Everyday.ogg";
			break;
		case 2:
			songToPlayLeft = "Calvin.ogg";
			break;
		case 3:
			songToPlayLeft = "Test.ogg";
			break;
		case 4:
			songToPlayLeft = "Yellow.ogg";
			break;
		case 5:
			songToPlayLeft = "TestPitch.ogg";
			break;
		case 6:
			songToPlayLeft = "testingPitch.wav";
			break;
		case 7:
			songToPlayLeft = "testingPitch.ogg";
			break;
		case 8:
			songToPlayLeft = "Enigma.ogg";
			break;
		case 9:
			songToPlayLeft = "L_R_Mono.wav";
			break;
		default:
			print ("pls select a song");
			break;
		}
		audioPaths = Application.dataPath + "/Resources" +"/Audio/" + songToPlayLeft;//Duplicated
		print(audioPaths);
		csoundunity.setStringChannel ("SongPlay", audioPaths);//Duplicated
		//csoundunity.setStringChannel ("SongPlay", songToPlayLeft);
	}

	void pitchAlgorithms(){
		csoundPitchL = Mathf.Pow(1.05946f,pitchToIncrease);
		//csoundunity.setChannel ("Pitch",csoundPitchL);
		/*
		float csoundPitch = Mathf.Pow(1.05946f,pitchToIncrease);
		csoundunity.setChannel ("Pitch",csoundPitch);
		*/
	}

	//What's the original BPM of the song and how much BPM you want to increase?
	void bpmAlgorithms(){
		float increase_one_bpm/*, csoundBPM*/;
		increase_one_bpm = 1 / originalbpm;
		print (increase_one_bpm);
		csoundbpmL = 1f + (increase_one_bpm * bpmToIncrease);
		//csoundunity.setChannel ("Time_Scaling",csoundbpmL);
		/*
		csoundBPM = 1f + (increase_one_bpm * bpmToIncrease);
		csoundunity.setChannel ("Time_Scaling",csoundBPM);
		*/
	}

	void checkTempoAndSongChange(){
		if (bpmNow != bpmPre) {
			bpmToIncrease = bpmNow - originalbpm;
			bpmAlgorithms ();
		}
		if (checkTestString != checkForStringPre) {
			checkForString ();
		}
		if (pitchNow != pitchPre) {
			pitchToIncrease = pitchNow - 1f;
			pitchAlgorithms ();
		}
		checkForStringPre = checkTestString;
		bpmPre = bpmNow;
		pitchPre = pitchNow;
	}

	void setUp(){
		bpmNow = originalbpm;
		bpmPre = originalbpm;
		pitchNow = 1f;
		pitchPre = 1f;
		songToPlayLeft = "Symphony.ogg";
		csoundunity.setChannel ("Time_Scaling",1f);
		//audioPaths = Application.dataPath + "/Resources/" +"/Audio/" + songToPlayLeft;//Duplicated
		//print(audioPaths);
		//csoundunity.setStringChannel ("SongPlay", audioPaths);
		//csoundunity.sendScoreEvent("i 1 0 3600");
		//csoundunity.setChannel ("fft",2048f);
	}

	void cuePoints(){
		csoundunity.setChannel ("SkipTime", skipTime);
	}

	void Update(){
		checkTempoAndSongChange ();
		cuePoints ();
	}
	void Start(){
		setUp ();
	}
}
