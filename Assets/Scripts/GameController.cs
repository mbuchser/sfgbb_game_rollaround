using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameController : MonoBehaviour {

	public float countdown;
	public Text labelCountdown;
	public GameObject player;
	public Button restartButton;
	public Button linkButton;
	public Button startButton;
	bool started = false;
	public GameObject startCurtain;
	private Rigidbody rb;

	void Start () {
		if (SystemInfo.deviceType == DeviceType.Handheld || SystemInfo.deviceType == DeviceType.Unknown) {
			startButton.gameObject.SetActive (false);
			labelCountdown.text = Commons.ERR_MSG_MOB_BROWSER;
		}
		rb = player.GetComponent<Rigidbody> ();
		restartButton.enabled = false;
		restartButton.gameObject.SetActive (false);
		linkButton.enabled = false;
		linkButton.gameObject.SetActive (false);
	}
	
	void Update () {

		if (started == true) {			
			countdown -= Time.deltaTime;
			labelCountdown.text = countdown.ToString ("F2");
			if (countdown < 0) {
				restartButton.enabled = true;
				restartButton.gameObject.SetActive (true);
				linkButton.enabled = true;
				linkButton.gameObject.SetActive (true);
				labelCountdown.text = Commons.MSG_GAME_OVER;
				GameOver ();
			}
		}
	}

	public void startStop(){
		if (started) {
			started = false;
			startButton.enabled = true;
			startButton.gameObject.SetActive (true);
			startCurtain.gameObject.SetActive (true);
			player.SendMessage ("startStop");
		} else {
			started = true;
			startButton.enabled = false;
			startButton.gameObject.SetActive (false);
			player.SendMessage ("startStop");
			startCurtain.gameObject.SetActive (false);
		}
	}

	void GameOver(){
		player.SetActive(false);
		player.GetComponent<Renderer> ().enabled = false;
	}	

}
