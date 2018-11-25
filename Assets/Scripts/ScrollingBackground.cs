using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
	Material m_bgMat;
	Vector3 _previousCameraPosition;
	Vector3 _defaultPosition;
	// Use this for initialization
	void Awake () {
		m_bgMat = GetComponent<MeshRenderer>().material;
		_defaultPosition = this.transform.position;

		GameplayEvents.CAMERA_CHANGED_POSITION += OnCameraUpdatePosition;
	}
	
	// Update is called once per frame
	void OnCameraUpdatePosition (Vector3 cameraPosition) {
		this.transform.position = new Vector3(_defaultPosition.x, cameraPosition.y, _defaultPosition.z);

		Vector3 offset = cameraPosition;
		
		m_bgMat.SetTextureOffset("_MainTex", new Vector2(offset.x, offset.y/10f));

		_previousCameraPosition = cameraPosition;
	}
}
