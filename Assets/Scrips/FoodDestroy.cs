using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDestroy : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") {
			ScoreManager.currentscore++;
            Destroy(this.gameObject);
        }
    }

}
