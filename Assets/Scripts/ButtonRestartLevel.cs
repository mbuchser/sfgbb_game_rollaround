using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ButtonRestartLevel : MonoBehaviour {

	public void goToLevel(string level ){
		SceneManager.LoadScene (level);
	} 

	void Start () {
		
	}
	
	void Update () {
		
	}
}
