using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {
	public static int currentscore;
	public static int reqscore;
	public static int currentlevel=1;
	public static int maxlevel=2;
	JsonData json;
	// Use this for initialization
	void Start () {
		currentscore = 0;
		reqscore = GetReqScore ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentscore == reqscore) {
			Debug.Log ("Level Completed");
			if (currentlevel == maxlevel)
				currentlevel = 1;
			else
				currentlevel++;
			SceneManager.LoadScene (0);
		}
		
	}
	int GetReqScore()
	{
		TextAsset file = Resources.Load("Level"+ScoreManager.currentlevel) as TextAsset;
		string content = file.ToString ();
		json = JsonMapper.ToObject (content);
		return int.Parse(json["food"][0].ToString());
	}
}
