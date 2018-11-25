using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

	[SerializeField] Transform target;
	Vector3 _offsetWithTarget;
	Vector3 _previousPosition = Vector3.zero;
	// Use this for initialization
	void Awake () {
		_offsetWithTarget = this.transform.position - target.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		Vector3 newPosition = target.position + _offsetWithTarget;
		this.transform.position = newPosition;
		
		GameplayEvents.CAMERA_CHANGED_POSITION.Raise(newPosition);

		_previousPosition = newPosition;
	}
}
