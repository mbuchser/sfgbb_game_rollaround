using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	private Rigidbody rb;
	public float reflectSpeed;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void OnCollisionExit(Collision collisionInfo){
		if (collisionInfo.gameObject.tag == Commons.TAG_ITEM) {
			rb.AddForce (Vector3.Reflect (transform.position, collisionInfo.contacts [0].normal) * reflectSpeed, ForceMode.Impulse);//this causes the ball to reflect off the surface
			transform.rotation = Quaternion.LookRotation (rb.velocity);
		}
	}
	
	void Update () {
		transform.Rotate (new Vector3 (0, 45, 0) * Time.deltaTime);
	}
}
