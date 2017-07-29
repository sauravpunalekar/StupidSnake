using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtcleEfct : MonoBehaviour {

    public GameObject explosion; // drag your explosion prefab here
    GameObject cheeseparticle; 

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter2D(Collider2D collision){		
		if (collision.gameObject.name == "Player(Clone)") {
            GetComponent<AudioSource>().Play();
            cheeseparticle = Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(-90,0,0))) as GameObject;
            Destroy(gameObject);
            ScoreManager.currentscore++;
            Destroy(cheeseparticle, 1); 
		}
	}

}
