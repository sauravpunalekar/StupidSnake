using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		
	}
	public void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Enemy(Clone)") {
			Destroy (col.gameObject);
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
