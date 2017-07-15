using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
	
public class LevelCreationSpawn : MonoBehaviour {
	public Text text1;
	RaycastHit2D hit;
	GameObject currentObject;
	float TouchTime;
	string enemy = "Tap on the screen to place enemies and long press on enemy to initialize its waypoints";
	string food = "Tap on the screen to place food";
	string way = "Tap on the screen to place waypoints for the snake";
	int state=1;
	int count=0;

	void Start () {
		text1.text = enemy;
		Instantiate ((GameObject)Resources.Load ("tick"));
	}
		
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			Touch touch = Input.touches [0];
			Vector2 fingerpos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			hit = Physics2D.Raycast (fingerpos, Vector2.zero);

			if (hit.collider != null && hit.collider.gameObject.name == "tick(Clone)" && state==1) {
				Debug.Log (state);
				state = 2;
				return;
			}


			if (hit.collider != null && hit.collider.gameObject.name == "tick(Clone)"&&state==2) {
				state = 3;
				count = GameObject.FindGameObjectsWithTag ("enemy").Length;


			}
				if (state==1) {
					Instantiate ((GameObject)Resources.Load ("EnemyStockPrefab"), fingerpos, new Quaternion (0, 0, 0, 0));
					Debug.Log (state);
				}
					if (state == 2) {
					
					Instantiate ((GameObject)Resources.Load ("Waypoint"), fingerpos, new Quaternion (0, 0, 0, 0));

					}
					if (state == 3) {
					
					Instantiate ((GameObject)Resources.Load ("CheeseStockPrefab"), fingerpos, new Quaternion (0, 0, 0, 0));
					Debug.Log (state);
				}
				}


			}
				
	}






