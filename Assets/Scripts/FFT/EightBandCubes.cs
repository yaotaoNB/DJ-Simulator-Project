using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightBandCubes : MonoBehaviour {

	public int _band;
	public float _startScale, _scaleMultiplier;
	public bool _useBuffer;
	Material _material;

	void Start () {
		_material = GetComponent <MeshRenderer>().materials[0];
	}

	void Update () {
		if (_useBuffer) {
			transform.localScale = new Vector3 (transform.localScale.x,(LeftChanelOne._bandBuffer[_band]*_scaleMultiplier)+_startScale,transform.localScale.z);
			Color _color = new Color (LeftChanelOne._audioBandBuffer[_band],LeftChanelOne._audioBandBuffer[_band],LeftChanelOne._audioBandBuffer[_band]);
			_material.SetColor ("_EmissionColor",_color);
		}
		if (!_useBuffer) {
			transform.localScale = new Vector3 (transform.localScale.x,(LeftChanelOne._freqBand[_band]*_scaleMultiplier)+_startScale,transform.localScale.z);
			Color _color = new Color (LeftChanelOne._audioBandBuffer[_band],LeftChanelOne._freqBand[_band],LeftChanelOne._audioBandBuffer[_band]);
			_material.SetColor ("_EmissionColor",_color);
		}

	}
}
