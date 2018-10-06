using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vol_Fader : MonoBehaviour {

	private Vector3 dist;
	float posX;
	float posY;
	public static float volumeL;

	void OnMouseDown(){
		dist = Camera.main.WorldToScreenPoint (transform.localPosition);
		//explain about this substraction
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.x - dist.y;

	}
	void OnMouseDrag () {
		
		Vector3 curPos = new Vector3 (Input.mousePosition.x - posX,Input.mousePosition.y - posY,dist.z);
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (curPos);
		transform.localPosition = new Vector3(Mathf.Clamp(worldPos.x,-0.45f,0.44f),transform.localPosition.y,transform.localPosition.z);

	}
	void Update(){
		volumeL = (- value (gameObject.transform.localPosition.x,-0.45f,0.44f,0f,1f)) + 1f;
	}
	float value(float thisvalue,float oldmin,float oldmax,float newmin,float newmax){
		thisvalue = (((thisvalue - oldmin) * (newmax - newmin)) / (oldmax - oldmin)) + newmin;
		return thisvalue;
	}
}
