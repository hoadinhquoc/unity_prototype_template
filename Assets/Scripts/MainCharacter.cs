using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

	[SerializeField] float speed = 1f;
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		transform.position += new Vector3(0f, speed * dt, 0f);
	}
}
