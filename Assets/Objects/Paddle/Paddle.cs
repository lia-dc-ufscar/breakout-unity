using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public Vector2 maxBounceVector = new Vector2(2.0f, 1.0f);
	
	// Use this for initialization
	void Start () {
		if (maxBounceVector.y <= 0.0f) Debug.LogError("BounceVector should be upwards");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.x = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, Camera.main.transform.position.z - transform.position.z)).x;
		transform.position = position;
	}
	
	void BallHit(Ball ball) {
		Vector2 dir = maxBounceVector;
		float relativePosition = (ball.transform.position.x - transform.position.x) / (collider.bounds.size.x / 2.0f);
		dir.x *= relativePosition;
		Debug.Log("Relative: " + relativePosition + " Dir: " + dir);
		ball.SetDirection(dir);
	}
}
