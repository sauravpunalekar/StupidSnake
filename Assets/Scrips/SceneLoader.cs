using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	Button button;
	// Use this for initialization
	void Start () {
		button = this.gameObject.GetComponent<Button> ();
		button.onClick.AddListener (() => loadScene ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void loadScene()
	{
		if (button.name == "PlayGame")
			SceneManager.LoadScene (1);
		else
			SceneManager.LoadScene (2);
	}
}
