using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float speed = 0.1f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Quaternion rot = Quaternion.LookRotation(  target.position- transform.position);
		transform.rotation = Quaternion.Lerp(transform.rotation, rot, speed);
	}
}
