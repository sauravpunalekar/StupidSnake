using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrtcleEfct : MonoBehaviour {

	public Transform boom;

	// Use this for initialization
	void Start () {
		boom.GetComponent<ParticleSystem> ().enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.name == "Player") {
			//ScoreManager.currentscore++;
			boom.GetComponent<ParticleSystem> ().enableEmission = true;
			//Destroy (this.gameObject);
			StartCoroutine (StopBoom());
		}
	}

	IEnumerator StopBoom() {
		yield return new WaitForSeconds(0.8f);
		boom.GetComponent<ParticleSystem> ().enableEmission = false;
		Destroy(this.gameObject);
	}
}
