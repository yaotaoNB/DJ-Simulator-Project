using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDJControl : BeatMatch {
    //using new keyword for instantiating the Play_Pause class here is not working, what's did you do last time for another script?
    //where did you trigger the audiosource.Play??
	public AudioSource audiosource;
	private Vector3 lastPos;
	private bool isDragging;
	public float defaultRotateSpeed = 1f;
	private List<float> smoothPitch;
	public int SmoothPitchCount = 10;
    Ray rayTest;
	[SerializeField]
	CsoundUnity csoundUnityCDJcontrol;
	void Start () {
		smoothPitch = new List<float> ();
		lastPos = Vector3.zero;
		isDragging = false;
	}
	
	void Update () {
        if (!isDragging && Play_Pause.isPlayingLeft)
        {
            float angle = defaultRotateSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(0f, angle, 0f));
			updatePitch(defaultRotateSpeed);
            Debug.DrawRay(rayTest.origin, rayTest.direction, Color.green);
        } else if (!isDragging && !Play_Pause.isPlayingLeft) {
				csoundUnityCDJcontrol.setChannel ("Time_Scaling", 0f);
				csoundUnityCDJcontrol.setChannel ("Pitch", 0f);
		}
	}

    //build-in Unity function while Mouse is down
	void OnMouseDown() {
		//Debug.Log("Button Down");
		Vector3 mousePos = Input.mousePosition;
        //Get the info(transform) back from the RayCast while hitting with the collider
		RaycastHit hit;
        //Declare a ray originate from near plane back to the camera center, position of the ray is changing in real time with the mousePos
		Ray ray = Camera.main.ScreenPointToRay(mousePos);
        rayTest = ray;
		if (Physics.Raycast(ray, out hit)) {
			Transform objectHit = hit.transform;
            //??1.objectHit == this.transformation??2.the ray is too short to hit the CD? or the length is infinite?
            //??3."this" keyword means this script?
			if (objectHit.tag == "CD" && objectHit == this.transform) {
				// is Dragging this
				//Debug.Log("Dragging");
				isDragging = true;
                //Debug.DrawRay(ray.origin,ray.direction,Color.green);
				lastPos = mousePos;
			}

		}

	}
    //build-in Unity function while Mouse is holding down
    void OnMouseDrag() {
		if (isDragging) {
			Vector3 mousePos = Input.mousePosition;
            //Transforms position from world space into screen space(pixel),centerPosition is the position of the camera
            Vector3 centerPos = Camera.main.WorldToScreenPoint(transform.position);
            //??4.
			Vector3 centerToLast = lastPos - centerPos;
			Vector3 centerToMouse = mousePos - centerPos;
			//Vector3 LastToMouse = lastPos - centerPos;

			float centerToLastAngle = Mathf.Rad2Deg * Mathf.Atan2(centerToLast.y, centerToLast.x);
			float centerToMouseAngle = Mathf.Rad2Deg *  Mathf.Atan2(centerToMouse.y, centerToMouse.x);
			float angle = (centerToMouseAngle - centerToLastAngle);

			if (Mathf.Abs(angle) > 180f) {
				if (centerToLastAngle < 0) centerToLastAngle += 360f;
				if (centerToMouseAngle < 0) centerToMouseAngle += 360f;
				angle = (centerToMouseAngle - centerToLastAngle);
			}

			angle = -angle;

			//Debug.Log("Dragging" + angle);
			transform.Rotate(new Vector3(0f, angle, 0f));
			updatePitch(angle / Time.deltaTime);
			/*
			Rigidbody rb = GetComponent<Rigidbody>();
			if (rb) {
				rb.AddTorque();
			}*/
			lastPos = mousePos;
		}

	}

	void OnMouseUp() {
		isDragging = false;
	}

	void OnMouseUpAsButton(){
		isDragging = false;
	}

	void updatePitch(float rotateSpeed) {
		float newPitch = rotateSpeed / defaultRotateSpeed;

		// update smoothPitch list
		smoothPitch.Add (newPitch);
		while (smoothPitch.Count > SmoothPitchCount) {
			smoothPitch.RemoveAt (0);
		}
		// get average
		float result = 0f;
		float count = smoothPitch.Count;
		foreach (float element in smoothPitch) {
			result += element / count;
		}
		//audiosource.pitch = result;
		if (isDragging) {
			//csoundunity.setChannel ("fft",1024f);
			csoundUnityCDJcontrol.setChannel ("Time_Scaling", result);
			csoundUnityCDJcontrol.setChannel ("Pitch", result);
			//print ("BPM is" + result + ", Pitch is" + result);
		} else if (!isDragging) {
			csoundUnityCDJcontrol.setChannel ("Time_Scaling", csoundbpmL);
			csoundUnityCDJcontrol.setChannel ("Pitch", csoundPitchL);
			//print ("BPM is" + csoundbpmL + ", Pitch is" + csoundPitchL);
		}
	}

}
