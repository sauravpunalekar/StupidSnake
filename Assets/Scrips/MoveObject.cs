using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
	Ray2D ray;
	RaycastHit2D hit;
	GameObject currentobject;
	float TouchTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		foreach (Touch t in Input.touches) {
			Touch touch = Input.touches [0];

			if (touch.phase == TouchPhase.Began) {
				TouchTime = Time.time;
				Vector2 touch1 = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				hit = Physics2D.Raycast (touch1, Vector2.zero);
				if (hit.collider.gameObject.name == "tick(Clone)") {
					currentobject = null;
					Destroy (GameObject.Find ("tick(Clone)"));
					Destroy(GameObject.Find("cross(Clone)"));
				}
				if (hit.collider.gameObject.name == "cross(Clone)") {
					Destroy (currentobject);
					Destroy (GameObject.Find ("tick(Clone)"));
					Destroy(GameObject.Find("cross(Clone)"));
				}
				if ((hit.collider != null)&&(hit.collider.gameObject.name!="tick(Clone)")&&(hit.collider.gameObject.name!="cross(Clone)")) {
					currentobject = hit.collider.gameObject;
				} 
				else {
					if(currentobject!=null)
					currentobject.transform.position = touch1;
				}
			}

			if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
				if (Time.time - TouchTime <= 0.5) {
					//do stuff as a tap​
				} else {
					Handheld.Vibrate ();
					//generateButtons ();
				}
			}


		}
	}
	void generateButtons(){
		
	}


}
