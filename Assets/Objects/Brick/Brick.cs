using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	void BallHit(Ball ball) {
		GameObject.FindGameObjectWithTag("GameController").SendMessage("OnBrickDestroyed");	
		Destroy(gameObject);
	}
	
	public void SetColor(Color color) {
		renderer.material.color = color;	
	}
}
