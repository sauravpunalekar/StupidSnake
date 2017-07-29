using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;
using UnityEngine.SceneManagement;


public class LevelGenerator2 : MonoBehaviour {
	public int count;
	public int path;
	public JsonData Gjson;
	public JsonData Ljson;
	// Use this for initialization
	void Start () {
		GenerateLevel();
		PlayerInit ();
		EnemyInit ();
		FoodInit();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void GenerateLevel(){

		TextAsset file = Resources.Load("levels1") as TextAsset;
		string content = file.ToString ();
		Gjson = JsonMapper.ToObject (content);
		//Debug.Log (Gjson.ToString());
		Gjson = Gjson [ScoreManager.currentlevel - 1];

	}

	void FoodInit() {
		Ljson = Gjson ["food"];
		int foodCount = Ljson.Count;
		for (int i = 0; i < foodCount; i++) {
			GameObject g = (GameObject)Resources.Load ("cheese 1");
			Instantiate (g).transform.position = new Vector3 (int.Parse(Ljson[i]["x"].ToString()),int.Parse(Ljson[i]["y"].ToString()),0);
		}
	}

	void EnemyInit() {
		Ljson = Gjson ["enemy"];
		int enemyCount = Ljson.Count;
		for (int i = 0; i < enemyCount; i++) {
			int pathCount = Ljson[i]["path"].Count;
			GameObject g = Resources.Load ("Enemy") as GameObject;
			g.GetComponent<EnemyAI2> ().pathCount = pathCount;
			Vector3[] pathVector = new Vector3[pathCount];
			for (int j = 0; j < pathCount; j++) {
				pathVector [j] = new Vector3 (int.Parse(Ljson[i]["path"][j]["x"].ToString()),int.Parse(Ljson[i]["path"][j]["y"].ToString()),0);
			}
			g.GetComponent<EnemyAI2> ().enemyPath = pathVector;
			g.transform.position = pathVector[0];
			Instantiate(g);	
		}
	}

	void PlayerInit() {
		Ljson = Gjson["player"];
		Instantiate ((GameObject)Resources.Load ("Player")).transform.position = new Vector3 (int.Parse(Ljson["x"].ToString()),int.Parse(Ljson["y"].ToString()),0);
	}
}
