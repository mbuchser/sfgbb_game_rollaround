using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerLevel4 : MonoBehaviour {

	public float countdown;
	public Text labelCountdown;
	public Text labelwin;
	public GameObject player;
	public Button restartButton;
	public Button linkButton;

	void Start () {
		restartButton.enabled = false;
		restartButton.gameObject.SetActive (false);
		linkButton.enabled = false;
		linkButton.gameObject.SetActive (false);
	}

	void Update () {
		countdown -= Time.deltaTime;
		labelCountdown.text = countdown.ToString("F2");
		if ( countdown < 0 ){
			restartButton.enabled = true;
			restartButton.gameObject.SetActive (true);
			linkButton.enabled = true;
			linkButton.gameObject.SetActive (true);
			labelCountdown.text = Commons.MSG_GAME_OVER;
			GameOver();
		}
	}

	void GameOver(){
		player.SetActive(false);
		player.GetComponent<Renderer> ().enabled = false;
		restartButton.enabled = true;
		restartButton.gameObject.SetActive (true);
		linkButton.enabled = true;
		linkButton.gameObject.SetActive (true);
	}



}
