using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightChanelOne : MonoBehaviour {

	void Update () {
		//GetComponent<AudioSource> ().volume = CrossFader.rightVol;
		GetComponent<AudioSource> ().volume = Vol_Fader_R.volumeR * CrossFader.rightVol;
		//print (GetComponent<AudioSource> ().volume);
		//print(CrossFader.rightVol);
	}
}
