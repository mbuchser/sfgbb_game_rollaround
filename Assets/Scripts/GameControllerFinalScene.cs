using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControllerFinalScene : MonoBehaviour {

	public Text labelCountdown;
	public Text labelwin;
	public Button restartButton;
	public Button linkButton;
	public Button submitButton;
	public Text nameList; 
	public Text infoText; 
	public InputField nameField;

	static string addNameURL = Commons.BACKEND_ADDNAME; 
	static string hofURL = Commons.BACKEND_HDISPLAY;

	void Start () {
		restartButton.enabled = true;
		restartButton.gameObject.SetActive (true);
		linkButton.enabled = true;
		linkButton.gameObject.SetActive (true);
		StartCoroutine (GetNames ());
	}

	void Update () {
	}

	void GameOver(){
	}

	public void submitName(){
		if (nameField.text != null) {
			StartCoroutine (postName (nameField.text));
		} else {
			print ("no name entered");
		}
	}

	IEnumerator postName(string name){
		string post_url = addNameURL + "name=" + WWW.EscapeURL (name) + "&app-key=<your-api-key-here>>";
		print (post_url);
		WWW hs_post = new WWW(post_url);
		yield return hs_post; 
		if (hs_post.error != null) {
			// TODO: display error dialog for user
			print ("There was an error posting the name: " + hs_post.error);
		} else {
			submitButton.gameObject.SetActive (false);
			infoText.text = Commons.MSG_CONGRATS;
			StartCoroutine (GetNames ());
		}
	}

	IEnumerator GetNames() {
		nameList.text = Commons.MSG_LOADING_NAMES;
		WWW hs_get = new WWW(hofURL);
		yield return hs_get;
		if (hs_get.error != null){
			// TODO: display error dialog for user
			print("There was an error getting the names: " + hs_get.error);
		}
		else {
			nameList.text = hs_get.text;
		}
	}

}
