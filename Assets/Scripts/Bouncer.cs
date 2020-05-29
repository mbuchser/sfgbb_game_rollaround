using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour {

	private Vector3 velocity = Vector3.zero;
	private float floorHeight = 0.0f;
	private float sleepThreshold = 0.05f;
	private float bounceCooef = 0.8f;
	private float gravity = -9.8f;
	private Vector3 tempPos = Vector3.zero;

	void Start(){
	}

	void FixedUpdate() {
		if (velocity.magnitude > sleepThreshold || transform.position.y > floorHeight) {
			velocity.y += gravity * Time.fixedDeltaTime;
		}
		transform.position += velocity * Time.fixedDeltaTime;
		if (transform.position.y <= floorHeight) {
			tempPos.y = floorHeight;
			transform.position = tempPos;
			velocity.y = -velocity.y;
			velocity *= bounceCooef;
		}
	}

}
