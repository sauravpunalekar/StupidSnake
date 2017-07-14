using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame  
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy(Clone)") {
			Destroy (collision.gameObject);
			Handheld.Vibrate ();

			StartCoroutine ("Blink");

           
        }
    }

	IEnumerator Blink()
	{
		for (int i = 0; i < 4; i++) {
			this.GetComponent<SnakeMovement> ().speed = 0;
			this.gameObject.GetComponent<Renderer> ().enabled = false;
			yield return new WaitForSeconds (0.1f);
			this.gameObject.GetComponent<Renderer> ().enabled = true;
			yield return new WaitForSeconds (0.1f);
		}
		SceneManager.LoadSceneAsync(1);
	}

}

