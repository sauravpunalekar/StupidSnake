using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtcleEfct : MonoBehaviour {

	public Transform boom;
	ParticleSystem cheese;
	 
	// Use this for initialization
	void Start () {
		cheese = boom.GetComponent<ParticleSystem> ();
		var em = cheese.emission;
		em.enabled = false;
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.name == "Player") {
            GetComponent<AudioSource>().Play();
            ScoreManager.currentscore++;
			var em = cheese.emission;
			em.enabled = true;
			GetComponent<Renderer> ().enabled = false;
			StartCoroutine (StopBoom());
		}
	}

	IEnumerator StopBoom() {
		yield return new WaitForSeconds(0.8f);
		var em = cheese.emission;
		em.enabled = false;
		Destroy(this.gameObject);
	}
}
