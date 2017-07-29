using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleEffect : MonoBehaviour {

    public GameObject explosion; // drag your explosion prefab here
    GameObject enemyParticle;


    // Use this for initialization
    void Start () {
	}

	void OnCollisionEnter2D(Collision2D collision){		
		if (collision.gameObject.name == "Enemy(Clone)") {
            enemyParticle = Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
            Destroy(gameObject);
            Destroy(enemyParticle, 1);
        }
	}

}
