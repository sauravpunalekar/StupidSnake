using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("H");
        if (collision.gameObject.name == "Player") {
            Debug.Log("Hi");
			ScoreManager.currentscore++;
            Destroy(this.gameObject);
        }
    }
}
