using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControlMainscene : MonoBehaviour {

	private int count;
	public float speed;
	public Text textCountLabel;
	public Text textWinLabel;
	public GameObject gameController;
	public Button linkButton;
	public GameObject simpleDetonation;
	public GameObject pixelExplosion;
	private Rigidbody rb;
	private bool hasMoved = false;
	private bool started = false;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
	}

	void FixedUpdate(){
		float moveHorzontal;
		float moveVertical;
		if (started == true) {
			if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android) {
				moveHorzontal = Input.acceleration.x;
				moveVertical = Input.acceleration.y;
			} else {
				moveHorzontal = Input.GetAxis (Commons.HORIZONTAL);
				moveVertical = Input.GetAxis (Commons.VERTIKAL);
			}
			Vector3 movement = new Vector3 (moveHorzontal, 0, moveVertical);
			rb.AddForce (movement * speed);
		}
	}
	void OnTriggerEnter(Collider other) {
		hasMoved = true;		
		if (other.gameObject.CompareTag (Commons.TAG_ITEM)) {
			other.gameObject.SetActive (false);
			Instantiate (pixelExplosion, gameObject.transform.position, Quaternion.identity);
			Destroy (other.gameObject);
			count += 1;
			if (count >= 4) {
				textWinLabel.text = Commons.MSG_PREPARE_FOR + "2.";
				textCountLabel.text = Commons.MSG_PREPARE_FOR + "2.";
				textWinLabel.enabled = false;	
				linkButton.enabled = true;
				linkButton.gameObject.SetActive (true);
				gameController.SendMessage ("delayCountdown");
				StartCoroutine (loadLevel2 ());
			}
		}
	}

	void SetCountText(){
		if (hasMoved == false) {
			if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android) {
				textCountLabel.text = "Level 1: " + Commons.MSG_COLLECT_MOVE_DEVICE;
			} else {
				textCountLabel.text = "Level 1: " + Commons.MSG_COLLECT_USE_ARROWS;
			}
		} 
	}
	public void startStop(){
		if (started == false) {
			started = true;
		} else {
			started = false;
		}
	}

	IEnumerator loadLevel2(){
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene (Commons.LEVEL2);
	}

}




