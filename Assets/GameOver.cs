using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}
	
	void OnGUI(){
		//if retry is pressed load game aka level 0
		GUI.contentColor = Color.red;
		/*
		if(GUI.Button(new Rect(Screen.width / 2-50, Screen.height/2 + 150,100,40), "Play Again?"))
		{
			Application.LoadLevel(0);
		}
		*/
		//else quit game 
		if(GUI.Button(new Rect(Screen.width / 2-50, Screen.height/2 + 200,100,40), "Quit"))
		{
			Application.Quit();
		}
	}
}
