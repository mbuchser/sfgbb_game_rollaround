using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainBallController : MonoBehaviour {

	private int count;
	public float speed;
	public Text textCountLabel;
	public Text textWinLabel;
	private Rigidbody rb;
	private bool hasMoved = false;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
	}

	void FixedUpdate(){
		float moveHorzontal;
		float moveVertical;
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			moveHorzontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y;
		} else {
			moveHorzontal = Input.GetAxis (Commons.HORIZONTAL);
			moveVertical = Input.GetAxis (Commons.VERTIKAL);
		}
		Vector3 movement = new Vector3 (moveHorzontal, 0, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		hasMoved = true;
		if (other.gameObject.CompareTag (Commons.TAG_DIAMOND_PINK)) {
			Destroy (other.gameObject);
			textWinLabel.text = Commons.MSG_YOU_WIN;
			Explode ();
		}
		if (other.gameObject.CompareTag (Commons.TAG_ITEM)) {
			other.gameObject.SetActive (false);
			Destroy (other.gameObject);
			count += 1;
			SetCountText ();
			if (count >= 8) {
				textWinLabel.text = Commons.MSG_YOU_WIN;
			}
		}
		if (other.gameObject.CompareTag(Commons.TAG_FLOOR) ){
			textWinLabel.text = Commons.MSG_GAME_OVER;;
			gameObject.SetActive(false);
			gameObject.GetComponent<Renderer> ().enabled = false;
		}
	}

	void SetCountText(){
		if (hasMoved == false) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				textCountLabel.text = Commons.MSG_COLLECT_MOVE_DEVICE_SHORT;
			} else {
				textCountLabel.text = Commons.MSG_COLLECT_MOVE_ARROWS_SHORT;
			}
		} else {
			textCountLabel.text = "Count: " + count.ToString ();
		}
	}

	void Explode() {
		var exp = GetComponent<ParticleSystem>();
		exp.Play();
		Destroy(gameObject);
	}

}
