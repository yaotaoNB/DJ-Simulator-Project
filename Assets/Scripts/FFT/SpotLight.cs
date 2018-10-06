using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLight : MonoBehaviour {

	public int _band;
	public float _minIntensity, _maxIntensity;
	Light _Light;

	void Start () {
		_Light = GetComponent<Light> ();
	}

	void Update () {
		_Light.intensity = (LeftChanelOne._audioBandBuffer [_band] * (_maxIntensity - _minIntensity)) + _minIntensity;
	}
}
