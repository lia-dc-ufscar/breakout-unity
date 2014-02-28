using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnFail () {
		FSM.Next("Fail");
	}
	
	void OnVictory () {
		Debug.Log("Victory");
		FSM.Next("Victory");
	}

	void OnBrickDestroyed () {
		Debug.Log("Destroyed");
		if (GameObject.FindGameObjectsWithTag("Brick").Length == 1) {
			Debug.Log("All Destroyed");
			OnVictory();
		}
	}
			
}
