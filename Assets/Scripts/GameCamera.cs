using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

	[SerializeField] Transform target;
	Vector3 _offsetWithTarget;
	Vector3 _previousPosition = Vector3.zero;
	Vector3 _defaultPosition;
	// Use this for initialization
	void Awake () {
		_defaultPosition = this.transform.position;
		_offsetWithTarget = this.transform.position - target.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		Vector3 newPosition = _defaultPosition;
		newPosition.y = target.position.y + _offsetWithTarget.y;
		this.transform.position = newPosition;
		
		GameplayEvents.CAMERA_CHANGED_POSITION.Raise(newPosition);

		_previousPosition = newPosition;
	}
}
