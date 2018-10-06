using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFader : MonoBehaviour {

	private Vector3 dist;
	float posX;
	float posY;
	public static float leftVol;
	public static float rightVol;
	float crossVol;

	void OnMouseDown(){
		dist = Camera.main.WorldToScreenPoint (transform.localPosition);
		//explain about this substraction
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.x - dist.y;

	}
	void OnMouseDrag () {

		Vector3 curPos = new Vector3 (Input.mousePosition.x - posX,Input.mousePosition.y - posY,dist.z);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y,Mathf.Clamp(worldPos.z,-0.43f,0.43f));

	}

	void CaculateVol(ref float volL,ref float volR, float checkVol){
		if (checkVol >= 0f && checkVol <= 0.5f) {
			volL = 1f;
			volR = (value (checkVol, 0.5f, 1f, 0f, 1f)) + 1f;
		} else if (checkVol > 0.5f && checkVol <= 1f) {
			volR = 1f;
			volL = (-value (checkVol, 0.5f, 1f, 0f, 1f)) + 1f;
		}
	}

	void Update(){
		crossVol = value (gameObject.transform.localPosition.z,-0.43f,0.43f,0f,1f);
		CaculateVol(ref leftVol,ref rightVol,crossVol);

	}
	float value(float thisvalue,float oldmin,float oldmax,float newmin,float newmax){
		thisvalue = (((thisvalue - oldmin) * (newmax - newmin)) / (oldmax - oldmin)) + newmin;
		return thisvalue;
	}
		
}
