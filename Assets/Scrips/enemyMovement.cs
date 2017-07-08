using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	public Vector3[] path;
	public int currentPoint = 0;

	// Use this for initialization
	void Start () {
		pointToPath ();
	}

	// Update is called once per frame
	void Update () {

		Vector3 dir = path[currentPoint] - transform.position;

        transform.position += dir * Time.deltaTime * new EnemyAI2().patrolSpeed;

		if (dir.magnitude < 1.0f) {
			currentPoint++;
			if (currentPoint >= path.Length) {
				currentPoint = 0;
			};
			pointToPath ();
		};
	}

	void pointToPath(){
		Vector3 direction = (path[currentPoint] - transform.position).normalized;
		transform.up = direction;
	}
}
