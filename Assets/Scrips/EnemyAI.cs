using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	public float normalSpeed = 2f;	// enemy patrolling speed
	public float chaseSpeed = 5f;	// enemy chase speed
	public float chaseWaitTime = 3f;	// time till enemy will chase player
	public float chaseTimer = 0f;
	public float lookAtDistance = 20f;	//used to give the radius of sight of enemy
	public GameObject player;	//give target(player) object
	private float distance;
	private Vector3 playerPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (player.transform.position, transform.position);
		if(distance > lookAtDistance) { // player not in sight
			Patrol();
		} else if (distance < lookAtDistance) { // player in radius of sight chase
			Chase ();
		}
	}

	void Patrol() {
		// normal movement
	}

	void Chase() {
		playerPosition = player.transform.position;
		if (chaseTimer < chaseWaitTime && distance < lookAtDistance) {
			transform.position = Vector3.MoveTowards (transform.position, playerPosition, Time.deltaTime * chaseSpeed);
			chaseTimer += Time.deltaTime*5;
			if (distance < 0.5f) {
				Kill ();
			}
		} else {
			chaseTimer = 0f;
			Patrol ();
		}
	}
    
	void Kill() {
		Destroy (player);
		Debug.Log ("Game Over!");
	}
}
