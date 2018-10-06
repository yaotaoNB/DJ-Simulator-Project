using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Pause : MonoBehaviour {

	[SerializeField]
	AudioSource leftsource;
    public static bool isPlayingLeft;
	public bool triggered;
	[SerializeField]
	CsoundUnity csoundunity;
	public void OnMouseDown()
    {
		switch(isPlayingLeft){
		case false:
			if (!triggered) {
				leftsource.Play ();
				csoundunity.sendScoreEvent ("i1 0 -1");
			}
			if (triggered) {
				//leftsource.pitch = 0.92f;
				leftsource.pitch = 1f;
			}
			isPlayingLeft = true;
			triggered = true;
			break;
		case true:
			//leftsource.pitch = 0f;
			csoundunity.setChannel("Time_Scaling",0f);
			csoundunity.setChannel("Pitch",0f);
			isPlayingLeft = false;
			break;
		}
			
    }
}
