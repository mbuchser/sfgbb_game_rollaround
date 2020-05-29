using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject mainBall;
	private Vector3 offset;

	void Start () {
		offset = transform.position - mainBall.transform.position;
		
	}
	
	void LateUpdate () {
		transform.position = mainBall.transform.position + offset;
	}
}
