using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour {
	/*
	 Powers:
	 	0: No Power active.
		1: Cloak: Player goes invisible and enemy cant chase.
	 */
	public static int powerflag = 0;
	public static int power1_duration = 5;
	static float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (powerflag == 1) {
			EnemyAI2.fieldDistance = 0;		
			timer -= Time.deltaTime;
			if (timer <= 0) {
				EnemyAI2.fieldDistance = 3;
				powerflag = 0;
			}
			return;
		}
	}

	public static void InitPower(Collision2D col)
	{
		if (col.gameObject.name.Contains ("1")) {
			powerflag = 1;
			timer = power1_duration;
		}
	}
}
