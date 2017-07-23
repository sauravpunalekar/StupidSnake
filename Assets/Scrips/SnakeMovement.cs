using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {
	
	float slope;
	float angle;
	Vector2 playerPosition;
	Vector2 mouseOnScreen;
	public Camera cam;
	Vector2 playerpos;
	Vector2 clickpos;
	Vector2  dir;
	public int speed;


	// Use this for initialization
	void Start () {
		playerpos = this.gameObject.transform.position;
		clickpos = new Vector2 (0, 0);
	}

	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0)) {
			PlayerRotate ();
		}
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            PlayerRotateTouch();
        }
		PlayerMove ();

	}

	void PlayerRotate () {
		playerPosition = Camera.main.WorldToViewportPoint (this.gameObject.transform.position);
		mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		float angle = AngleBetweenTwoPoints(playerPosition, mouseOnScreen);
		this.gameObject.transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle+90));
		dir = (Camera.main.ScreenToWorldPoint (Input.mousePosition) - this.gameObject.transform.position);
		dir.Normalize ();
	}

    void PlayerRotateTouch() {
        playerPosition = Camera.main.WorldToViewportPoint(this.gameObject.transform.position);
        mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
        float angle = AngleBetweenTwoPoints(playerPosition, mouseOnScreen);
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
        dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.gameObject.transform.position);
        dir.Normalize();
    }

	float AngleBetweenTwoPoints (Vector3 a,Vector3 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

	void PlayerMove () {
		this.gameObject.transform.Translate(dir.x *Time.deltaTime*speed,dir.y*Time.deltaTime*speed, 0,Space.World);
	}
}
