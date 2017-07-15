using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour {
    public float minX;
    public float minY;
    public float maxX;
	public float maxY;
	
	// Update is called once per frame
	void Update () {
		float x = transform.position.x;
		float y = transform.position.y;
		if (x < minX)
			x = maxX;
		else if (x > maxX)
			x = minX;
		if (y < minY)
			y = maxY;
		else if (y > maxY)
			y = minY;
		transform.position = new Vector2 (x, y);
	}
}
