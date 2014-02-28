using UnityEngine;
using System.Collections;

public class NextStateWhenFilled : MonoBehaviour {
	
	void OnFilled() {
		TextMesh text = GetComponent<TextMesh>();
		string transition = "";
		if (text) transition = text.text;
		FSM.Next(transition);	
	}
}