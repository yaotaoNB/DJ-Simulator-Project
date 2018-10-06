using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class InstantiateBinsLeft : MonoBehaviour {
	/*[DllImport("SoundTouch")]
	private static extern long soundtouch ();*/

	public GameObject _sampleCubePrefab;
	GameObject[] _sampleCube = new GameObject[512];
	public float _maxScale;

	void Start () {
		for (int i = 0; i < 512; i++) {
			GameObject _instanceSamplesCube = (GameObject)Instantiate (_sampleCubePrefab);
			_instanceSamplesCube.transform.position = this.transform.position;
			_instanceSamplesCube.transform.parent = this.transform;
			_instanceSamplesCube.name = "SampleCube" + i;
			this.transform.eulerAngles = new Vector3 (0,-0.703125f*i,0);
			_instanceSamplesCube.transform.position = Vector3.forward * 100;
			_sampleCube [i] = _instanceSamplesCube;

		}
	}

	void Update () {
		for (int i = 0; i < 512; i++) {
			if (_sampleCube != null)
				_sampleCube [i].transform.localScale = new Vector3 (0.5f,(LeftChanelOne._samplesLeft[i]*_maxScale)+2,0.5f);
		}
	}
}
