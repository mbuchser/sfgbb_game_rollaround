using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerLevel2 : MonoBehaviour {

	public float countdown;
	public Text labelCountdown;
	public Text labelwin;
	public GameObject player;
	public Button restartButton;
	public Button linkButton;
	public Camera flyaroundCam;
	Camera mainCam;
	private Rigidbody rb;
	private bool hasMoved = false;
	private bool paused = false;
	Animator anim;

	void Start () {
		rb = player.GetComponent<Rigidbody> ();
		restartButton.enabled = false;
		restartButton.gameObject.SetActive (false);
		linkButton.enabled = false;
		linkButton.gameObject.SetActive (false);
		mainCam = Camera.main;
		anim = flyaroundCam.GetComponent<Animator> ();
		anim.enabled = false;
	}

	void Update () {
		if (paused == false) {
			countdown -= Time.deltaTime;
		}
		labelCountdown.text = countdown.ToString ("F2");
		if (countdown < 0) {
			restartButton.enabled = true;
			restartButton.gameObject.SetActive (true);
			labelCountdown.text = Commons.MSG_GAME_OVER;
			GameOver ();
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			if (mainCam.enabled) 	{
				pauseGame ();
				anim.enabled = true;
				flyaroundCam.GetComponent<Animator> ().Play ("FlyAroundCamera");
				mainCam.enabled = false;
			} else {
				continueGame ();
				anim.enabled = false;
				mainCam.enabled = true;
			}
				
		}
	}

	void pauseGame(){
		paused = true;
		rb.angularVelocity = Vector3.zero;
		rb.constraints = RigidbodyConstraints.FreezeAll;
		rb.velocity = Vector3.zero;
	}

	void continueGame(){
		paused = false;
		rb.constraints = RigidbodyConstraints.None;
	}

	void GameOver(){
		player.SetActive(false);
		player.GetComponent<Renderer> ().enabled = false;
	}

	IEnumerator loadFirstScene(){
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene (Commons.MAIN_SCENE);
	}
	
}
