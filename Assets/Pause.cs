using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
	//public GameObject pausePanel;
	//public Text buttonText;

	private bool isPaused;

	public void Start(){
		isPaused=false;
		Time.timeScale = 1;
		/*pausePanel.SetActive (false);
		SetChildrenActive(false);*/
	}
	private void Update(){
		if (Input.GetKeyDown (KeyCode.Z)) {
			//KeyCode.Return
			Debug.Log ("Pressed Z");
			pause ();
		}
	}
	public void pause(){
		if (isPaused) {
			Time.timeScale = 1;
			isPaused = false;
			/*pausePanel.SetActive (false);
			SetChildrenActive(false);
			//buttonText.text = "PAUSE";*/
		} else {
			Time.timeScale = 0;
			isPaused = true;
			/*pausePanel.SetActive (true);
			SetChildrenActive(true);
			//buttonText.text = "Continue";*/
		}

	}
	public void SetChildrenActive (bool active) {
		//SetChildrenActive (pausePanel, active);
	}

	private void SetChildrenActive (GameObject obj, bool active) {
		// Look at all of the children of the object passed in
		for (int i=0; i < obj.transform.childCount; i++) {
			// Get the child object to modify
			GameObject childObj = obj.transform.GetChild(i).gameObject;
			// Set that object's active state.
			childObj.SetActive (active);
			// Call this function on that object to set its children.
			SetChildrenActive (childObj, active);
		}
	}
}
