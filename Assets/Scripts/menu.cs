using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {

	void OnGUI () {
		
		GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 300, 200));
		//GUI.Box (new Rect (0,0,200,100), "Super Man - The Game");
		//GUI.Button (new Rect (40,10,80,30), "Start");
		GUILayout.Box("Super Man - The Game");
		if(GUILayout.Button("Start")) {
			Application.LoadLevel("SuperMan");	
		}
		GUI.EndGroup ();
	}
}
