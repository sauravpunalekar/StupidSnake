using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtcleEfct : MonoBehaviour {

	public Transform boom;
	ParticleSystem cheese;
	ParticleSystem.EmissionModule em;
	 
	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		boom.GetComponent<ParticleSystem> ().enableEmission = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
=======
		cheese = boom.GetComponent<ParticleSystem> ();
		em = cheese.emission;
		em.enabled = false;
>>>>>>> 1575590c19ecdce1215312c65b75b3b75b8a5ead
	}

	void OnCollisionEnter2D(Collision2D collision){		
		if (collision.gameObject.name == "Player") {
			GetComponent<PolygonCollider2D> ().enabled = false;
            GetComponent<AudioSource>().Play();
			em.enabled = true;
			GetComponent<Renderer> ().enabled = false;
			ScoreManager.currentscore++;
			StartCoroutine (StopBoom());
		}
	}

	IEnumerator StopBoom() {
		yield return new WaitForFixedUpdate ();
		yield return new WaitForSeconds(1.2f);
		em.enabled = false;
		Destroy(this.gameObject);
	}
}
