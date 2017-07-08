using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class LevelGenerator : MonoBehaviour {
	public static int count;
	public static int path;
	JsonData json;
	// Use this for initialization
	void Start () {
		json = JsonMapper.ToObject (File.ReadAllText(Application.dataPath+"/Scrips/Enemy.json"));
		int count = int.Parse (json ["count"].ToString());
		for (int i = 0; i < count; i++) {
			GameObject g = (GameObject)Resources.Load ("Enemy");
			int path = int.Parse (json ["enemy" + (i+1).ToString ()][0].ToString());
            g.GetComponent<EnemyAI2>().pathCount = path;
			Vector3[] v = new Vector3[path];
			for (int j = 0; j < path*2; j+=2) {
				v [j/2] = new Vector3 (int.Parse (json ["enemy" + (i+1).ToString ()][j+1].ToString()),int.Parse (json ["enemy" + (i+1).ToString ()][j+2].ToString()),0);

			}

            Instantiate(g);
            g.GetComponent<EnemyAI2>().enemyPath = v;
            g.transform.position = v[0];
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
