using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControlLevel2 : MonoBehaviour {


	private int count;
	public float speed;
	public Text textCountLabel;
	public Text textWinLabel;
	public Button restartButton;
	public Button linkButton;
	public GameObject simpleDetonation;
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
	void OnTriggerEnter(Collider other) {
		hasMoved = true;
		if (other.gameObject.CompareTag (Commons.TAG_ITEM)) {
			other.gameObject.SetActive (false);
			Instantiate (simpleDetonation, other.gameObject.transform.position, Quaternion.identity);
			Destroy (other.gameObject);
			count += 1;
			if (count >= 3) {
				textWinLabel.text = Commons.MSG_PREPARE_FOR +  "3.";
				textCountLabel.text = Commons.MSG_PREPARE_FOR +  "3.";
				textWinLabel.enabled = false;
				StartCoroutine (loadLevel3 ());
			}
		}
		if (other.gameObject.CompareTag(Commons.TAG_FLOOR) ){
			textCountLabel.text = Commons.MSG_GAME_OVER;
			textWinLabel.text = Commons.MSG_GAME_OVER;
			gameObject.SetActive(false);
			textWinLabel.gameObject.SetActive(false);
			textWinLabel.enabled = false;
			restartButton.enabled = true;
			restartButton.gameObject.SetActive (true);
			linkButton.enabled = true;
			linkButton.gameObject.SetActive (true);
		}
	}

	void SetCountText(){
		if (hasMoved == false) {
			if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android) {
				textCountLabel.text = "Level 2: " + Commons.MSG_COLLECT_MOVE_DEVICE;
			} else {
				textCountLabel.text = "Level 2: " + Commons.MSG_COLLECT_USE_ARROWS;
			}
		} 
	}

	IEnumerator loadFirstScene(){
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene (Commons.MAIN_SCENE);
	}

	IEnumerator loadLevel2(){
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene (Commons.LEVEL2);
	}

	IEnumerator loadLevel3(){
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene (Commons.LEVEL3);
	}

}




