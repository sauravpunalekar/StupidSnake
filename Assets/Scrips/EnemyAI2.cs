using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI2 : MonoBehaviour {

    public float chaseSpeed;
    public float patrolSpeed;
    public float distanceBetween;
    public float fieldDistance;
    public float lockTimer;
    public GameObject player;
    public Vector3 playerPosition;
    public Vector3[] enemyPath;
    public int pathCount;
    int currentPathPoint = 0;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        distanceBetween = Vector3.Distance(player.transform.position, transform.position);
        if (distanceBetween < fieldDistance) {
            lockTimer = 2f;
            Chase();
        }
        if (distanceBetween > fieldDistance) {
            Patrol();
        }
	}

    void Patrol() {
        pointToPath();
        Vector3 dir = enemyPath[currentPathPoint] - transform.position;
        Vector3 direction = (enemyPath[currentPathPoint] - transform.position).normalized;
        transform.position += direction * Time.deltaTime * patrolSpeed;
        if (dir.magnitude < 1.0f)
        {
            currentPathPoint++;
            if (currentPathPoint >= enemyPath.Length)
            {
                currentPathPoint = 0;
            };
            pointToPath();
        }
    }

    void Chase() {
        playerPosition = player.transform.position;
        PointToPlayer();
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * chaseSpeed);
        if (distanceBetween > fieldDistance) {
            if (lockTimer <= 0)
            {
                ReturnToPatrol();
            }
            lockTimer -= Time.deltaTime;
        }
    }

    void ReturnToPatrol() {

    }

    void pointToPath()
    {
        Vector3 direction = (enemyPath[currentPathPoint] - transform.position).normalized;
        transform.up = direction;
    }

    void PointToPlayer() {
        Vector3 direction = (playerPosition - transform.position).normalized;
        transform.up = direction;
    }

}
