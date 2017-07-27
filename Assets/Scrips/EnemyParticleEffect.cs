using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleEffect : MonoBehaviour {

	public Transform boom;
	ParticleSystem enemy;
	ParticleSystem.EmissionModule em;


	// Use this for initialization
	void Start () {
		enemy = boom.GetComponent<ParticleSystem> ();
		em = enemy.emission;
		em.enabled = false;
	}

	void OnCollisionEnter2D(Collision2D collision){		
		if (collision.gameObject.name == "Enemy(Clone)") {
			GetComponent<PolygonCollider2D> ().enabled = false;
			GetComponent<EnemyAI2> ().enabled = false;
			em.enabled = true;
			GetComponent<Renderer> ().enabled = false;
			StartCoroutine (StopBoom());
		}
	}

	IEnumerator StopBoom() {
		yield return new WaitForFixedUpdate ();
		yield return new WaitForSeconds(1.8f);
		em.enabled = false;
		Destroy(this.gameObject);
	}

}
