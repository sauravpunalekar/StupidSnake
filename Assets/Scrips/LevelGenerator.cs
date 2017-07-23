using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour {
	public int count;
	public int path;
	public JsonData json;
	// Use this for initialization
	void Start () {
		GenerateLevel ();
	}

	// Update is called once per frame
	void Update () {

	}
	public void GenerateLevel(){

		TextAsset file = Resources.Load("Levels") as TextAsset;
		string content = file.ToString ();
		json = JsonMapper.ToObject (content);
		json = json ["Levels"] [ScoreManager.currentlevel - 1];
		EnemyInit ();
		FoodInit();
	}
	void EnemyInit(){
		int count = int.Parse (json ["count"].ToString());
		for (int i = 0; i < count; i++) {
			int path = int.Parse (json ["enemy" + (i+1).ToString ()][0].ToString());
			GameObject g = Resources.Load ("Enemy") as GameObject;
			g.GetComponent<EnemyAI2>().pathCount = path;
			Vector3[] v = new Vector3[path];
			for (int j = 0; j < path*2; j+=2) {
				v [j/2] = new Vector3 (int.Parse (json ["enemy" + (i+1).ToString ()][j+1].ToString()),int.Parse (json ["enemy" + (i+1).ToString ()][j+2].ToString()),0);
				Debug.Log (v[j/2].ToString());
			}
			g.GetComponent<EnemyAI2> ().enemyPath = v;
			g.transform.position = v[0];
			Instantiate(g);	




		}
	}


	void FoodInit() {
		int foodcount = int.Parse(json["food"][0].ToString());
		for (int i = 1; i <= foodcount*2; i+=2) {
			float x = float.Parse(json["food"][i].ToString());
			float y = float.Parse(json["food"][i+1].ToString());
			GameObject g = (GameObject)Resources.Load("cheese 1");
			Instantiate(g).transform.position = new Vector3(x, y, 0);
		}
	}

}