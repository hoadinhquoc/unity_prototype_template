using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

	[SerializeField] float speed = 1f;
	// Use this for initialization
	void Awake () {
		GameplayEvents.INPUT_CONTROL += OnInputEvent;
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		transform.position += new Vector3(0f, speed * dt, 0f);
	}

	void OnInputEvent(ControlAction action)
	{
		switch(action)
		{
			case ControlAction.SWIPE_LEFT:
				transform.position += new Vector3(-1f, 0f, 0f);
				break;

			case ControlAction.SWIPE_RIGHT:
				transform.position += new Vector3(1f, 0f, 0f);
				break;
		}
	}
}
