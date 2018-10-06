using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class EQ : MonoBehaviour {

	public AudioMixer Filter;
	public static float fcLpf;//range 0 to 2
	public static float fcHpf;//range 0 to 2
	public static float fc;//range -1 to +1
	private Vector3 lastPos;

	public float rotSpeed = 200f;

	public float minRotation = 0f;
	public float maxRotation = 180f;

	public float storeVal = 90f;

	public float value(float thisvalue,float oldmin,float oldmax,float newmin,float newmax){
		thisvalue = (((thisvalue - oldmin) * (newmax - newmin)) / (oldmax - oldmin)) + newmin;
		return thisvalue;
	}

	void OnMouseDrag () {
		float rotationY = Input.GetAxis ("Mouse Y") * rotSpeed*Time.deltaTime;
		transform.Rotate (Vector3.up, rotationY);
		Vector3 currentRotation = transform.localRotation.eulerAngles;
		currentRotation.y = Mathf.Clamp (currentRotation.y, minRotation, maxRotation);
		print (currentRotation.y);
		//storeVal = currentRotation.y;
		transform.localRotation = Quaternion.Euler (currentRotation);
	}

	public void SetCutOff(){
		Filter.SetFloat ("LPF",Mathf.Sqrt(fcLpf * (1f + fc)));
		Filter.SetFloat ("HPF",Mathf.Sqrt(fcHpf * (1f - fc)));
	}

	void checkGameObject(){
		if (gameObject.tag == "HighEnd") {
			storeVal = transform.localRotation.eulerAngles.y;
			fcLpf = value (storeVal,0f,180f,0.01f,2f);
			//print (storeVal);
		}else if(gameObject.tag == "LowEnd"){
			storeVal = transform.localRotation.eulerAngles.y;
			fcHpf = value (storeVal,0f,180f,0.01f,2f);
			//print (storeVal);
		}else if(gameObject.tag == "Filter"){
			storeVal = transform.localRotation.eulerAngles.y;
			fc = value (storeVal,0f,180f,-1f,1f);
			//print (storeVal);
		}
	}

	void Update(){
		SetCutOff ();
		checkGameObject ();
	}

}
