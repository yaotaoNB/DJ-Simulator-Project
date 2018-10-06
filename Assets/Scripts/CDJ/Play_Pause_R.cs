using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Pause_R : MonoBehaviour {

	[SerializeField]
	AudioSource rightsource;
	public static bool isPlayingRight;
	public bool triggeredR;
	public void OnMouseDown()
	{
		switch(isPlayingRight){
		case false:
			if (!triggeredR)
				rightsource.Play ();
			if (triggeredR)
				rightsource.pitch = 1f;;
			isPlayingRight = true;
			triggeredR = true;
			break;
		case true:
			rightsource.pitch = 0f;;
			isPlayingRight = false;
			break;
		}

	}
}
