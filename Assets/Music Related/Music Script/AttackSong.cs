using UnityEngine;
using System.Collections;

public class AttackSong : MonoBehaviour {

	private Transform note1Target;
	private Transform note2Target;
	private Transform note3Target;

	/*
	[SerializeField]
	public GameObject[] notes;
	*/

	float tempPos;
	public GameObject note1;
	public GameObject note2;
	public GameObject note3;

	public float songLength = 0;

	public KeyCode num1;
	public KeyCode num2;
	public KeyCode num3;

	public static string destroyNote1 = "no";
	public static string destroyNote2 = "no";
	public static string destroyNote3 = "no";

	float tempPos1 = 0;
	float tempPos2 = 0;
	float tempPos3 = 0;



	// Use this for initialization
	void Start () {
		//songTarget = GameObject.Find ("NoteButtons").transform;


		note1Target = GameObject.Find ("Red Note Button").transform;
		note2Target = GameObject.Find ("Blue Note Button").transform;
		note3Target = GameObject.Find ("Green Note Button").transform;
	
		//tempPos = songTarget.position.x - 6.7f;

	}
	
	// Update is called once per frame
	void Update () {
		tempPos1 = note1Target.position.x;
		tempPos2 = note2Target.position.x;
		tempPos3 = note3Target.position.x;

		//songTarget = GameObject.Find ("NoteButtons").transform;
		//tempPos = songTarget.position.x - 4.65f;

		/*
		for (int i = 0; i < notes.Length; i++) {
			Instantiate (notes [i], new Vector3 ((tempPos + i), (songTarget.position.y + 4), 0), Quaternion.identity);
		}
		*/


	}

	void FixedUpdate(){

		songLength += Time.deltaTime;

		//tweak these if i dont like it
		if((songLength >= .1) && (songLength <= .125))
		{
			Instantiate (note1, new Vector3 (tempPos1, (note1Target.position.y + 4), 0), Quaternion.identity);

		}
		 
		if((songLength >= 1) && (songLength <= 1.025))
		{
			Instantiate (note2, new Vector3 (tempPos2, (note2Target.position.y + 4), 0), Quaternion.identity);
			
		}
		if((songLength >= 1.75) && (songLength <= 1.775))
		{
			Instantiate (note3, new Vector3 (tempPos3, (note3Target.position.y + 4), 0), Quaternion.identity);
			
		}
		if((songLength >= 2.75) && (songLength <= 2.775))
		{
			Instantiate (note2, new Vector3 (tempPos2, (note2Target.position.y + 4), 0), Quaternion.identity);
			
		}
		if((songLength >= 3.5) && (songLength <= 3.525))
		{
			Instantiate (note1, new Vector3 (tempPos1, (note1Target.position.y + 4), 0), Quaternion.identity);
			
		}






	}

	void OnTriggerStay2D(Collider2D other)
	{
		if ((Input.GetKeyDown (KeyCode.Alpha1)) && (other.gameObject.name == "Red Note(Clone)")) 
		{
			destroyNote1 = "yes";
		}
		if ((Input.GetKeyDown (KeyCode.Alpha2)) && (other.gameObject.name == "Blue Note(Clone)")) 
		{
			destroyNote2 = "yes";
		}
		if ((Input.GetKeyDown (KeyCode.Alpha3)) && (other.gameObject.name == "Green Note(Clone)")) 
		{
			destroyNote3 = "yes";
		}
	}



}
