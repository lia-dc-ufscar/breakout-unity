using UnityEngine;
using System.Collections;

public class FSM {

	public static void Next() {
		FSM.Next("");
	}
	
	public static void Next(string input) {
		string nextLevel = "";
		string currentLevel = Application.loadedLevelName;
		if (currentLevel == "Collect") {
			if (input == "Yes") {
				nextLevel = "Game";
			}
			else if (input == "No") {
				nextLevel = "Fail";
			}
		}
		else if (currentLevel == "Game") {
			if (input == "Fail") {
				nextLevel = "Fail";
			}
			else if (input == "Victory") {
				nextLevel = "Victory";
			}			
		}			
		else if (currentLevel == "Victory" || currentLevel == "Fail") {
			nextLevel = "Collect";
		}
		Application.LoadLevel(nextLevel);
		
	}
	
}
