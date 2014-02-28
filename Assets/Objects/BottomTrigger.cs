using UnityEngine;
using System.Collections;

public class BottomTrigger : MonoBehaviour {

	void BallHit(Ball ball) {
		GameObject.FindGameObjectWithTag("GameController").SendMessage("OnFail");	
	}
}
