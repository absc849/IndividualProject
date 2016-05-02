using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackSong : MonoBehaviour {

	private Transform note1Target;
	private Transform note2Target;
	private Transform note3Target;
	public Transform scoreObj;

	public static GameObject NoteButtons;


	//AttackSong.enabled = false;

	//List<float> noteSelection = new List<float>() {0.1f,3.0f,6.0f,9.0f,12.0f,15.0f,18.0f,21.0f,25.0f,29.5f} ;

	//List<float> noteSelection = new List<float>() {0.50f,1.0f,1.5f,2.0f,2.5f,3.0f,3.5f,4.0f,4.5f,5.0f} ; 

	List<float> noteSelection = new List<float>() {0.25f,0.5f,0.75f,2.25f,2.5f,2.75f,4.25f,4.5f,4.75f,6.25f} ; 

	public int pickNoteValue = 0;
	/*
	[SerializeField]
	public GameObject[] notes;
	*/

	public GameObject note1;
	public GameObject note2;
	public GameObject note3;

	public float songLength = 0;
	public float buttonTimer = 0;

	public KeyCode num1;
	public KeyCode num2;
	public KeyCode num3;

	public static string destroyNote1 = "no";
	public static string destroyNote2 = "no";
	public static string destroyNote3 = "no";

	public static bool songIsPlaying;
	private bool enoughNotes;

	

	public static int correctNotes = 0;
	//probs wont need this
	//	public static int bestStreak = 0;
	//if every song has the same amount of notes dont use this
	// public static int totalNotes = 0;

	public static float tempPos1 = 0;
	public static float tempPos2 = 0;
	public static float tempPos3 = 0;

	public AudioSource AS;


	/*
	private float songSpeed;
	private float bpm1 = 111f;
	private float crotchet;
	private float offset = 0.2;
	private float songposition;
	*/




	// Use this for initialization
	void Start () {
		NoteButtons = GameObject.Find ("NoteButtons");
		//PlayerRigidBody = GetComponent<Rigidbody2D>();
		NoteButtons.SetActive (false);
		//enable 
//	if (NoteButtons.activeSelf) {
////			NoteButtons.SetActive (true);
//			AS = GetComponent<AudioSource> ();
//			songIsPlaying = true;
//			//Player.PlayerInstance.usingRhythm = true;
//
//			note1Target = GameObject.Find ("Red Note Button").transform;
//			note2Target = GameObject.Find ("Blue Note Button").transform;
//			note3Target = GameObject.Find ("Green Note Button").transform;
//
//		}
	
	
		//tempPos = songTarget.position.x - 6.7f;

	}

	void OnEnable() 
	{
					//	NoteButtons.SetActive (true);

			AS = GetComponent<AudioSource> ();
			songIsPlaying = true;
			enoughNotes = false;
			AS.Play ();
			pickNoteValue = 0;
			Notes.maxNotes = 9;
			SoundManager.SoundInstance.PauseMusic ();
			note1Target = GameObject.Find ("Red Note Button").transform;
			note2Target = GameObject.Find ("Blue Note Button").transform;
			note3Target = GameObject.Find ("Green Note Button").transform;
			
	}

	void OnDisable()
	{
		SoundManager.SoundInstance.PlayMusic (SoundManager.SoundInstance.MainClip);
		songLength = 0;
		Debug.Log (Notes.maxNotes);
		Debug.Log (pickNoteValue);
		//Player.PlayerInstance.doSpecialAttack (0);
		if (enoughNotes == true) {
			Player.PlayerInstance.doRhythmAttack ();
			enoughNotes = false;
		}
		Player.PlayerInstance.usingRhythm = false;

	}


	// Update is called once per frame
	void Update () {
		NoteButtons = GameObject.Find ("NoteButtons");

		if (NoteButtons.activeInHierarchy) {

			tempPos1 = note1Target.position.x;
			tempPos2 = note2Target.position.x;
			tempPos3 = note3Target.position.x;
		}
		//songTarget = GameObject.Find ("NoteButtons").transform;
	


	}

	void FixedUpdate(){

		if (NoteButtons.activeInHierarchy) 
		{
			songLength += Time.deltaTime;
			scoreObj.GetComponent<TextMesh> ().text = "Score: " + correctNotes.ToString ();


			//add more picknotevalues for more note instantiations


			// when you add more notes increment the [9]
			if ((songLength >= noteSelection [pickNoteValue]) && (songLength <= noteSelection [9])) {
				if (songIsPlaying) {
					SoundManager.SoundInstance.StopCoroutine ("WaitAndPlay");
					//AS.Play ();
					songIsPlaying = false;
				}

				if (pickNoteValue == 0 || pickNoteValue == 3 || pickNoteValue == 7) {
					Instantiate (note1, new Vector3 (tempPos1, (note1Target.position.y + 4), 0), Quaternion.identity);
				}

				if (pickNoteValue == 1 || pickNoteValue == 9 || pickNoteValue == 5 || pickNoteValue == 8) {
					Instantiate (note2, new Vector3 (tempPos2, (note2Target.position.y + 4), 0), Quaternion.identity);
				}

				if (pickNoteValue == 2 || pickNoteValue == 6 || pickNoteValue == 4) {
					Instantiate (note3, new Vector3 (tempPos3, (note3Target.position.y + 4), 0), Quaternion.identity);
				}

				pickNoteValue += 1;
			}


		if ((pickNoteValue == 9) && (Notes.maxNotes <= 0))
		{
				buttonTimer += Time.deltaTime;

				if(correctNotes > 5)
				{
					enoughNotes = true;
				}
				if(buttonTimer >= 2 ){
					NoteButtons.SetActive(false);

		}
		}

		
		
		}






	}

	public bool getUsingRhythm()
	{
		return Player.PlayerInstance.usingRhythm;
	}

	private IEnumerator stopAttack()
	{
		yield return new WaitForSeconds (2.0f);
		pickNoteValue = 0;
		Notes.maxNotes = 9;
		Player.PlayerInstance.usingRhythm = false;


	}

	void OnTriggerStay2D(Collider2D other)
	{
		if ((Input.GetKeyDown (num1)) && (other.gameObject.name == "Red Note(Clone)")) 
		{
			destroyNote1 = "yes";
			Notes.maxNotes-=1;
			Debug.Log (Notes.maxNotes);

		}
		else if ((Input.GetKeyDown (num2)) && (other.gameObject.name == "Blue Note(Clone)")) 
		{
			destroyNote2 = "yes";
			Notes.maxNotes-=1;
			Debug.Log (Notes.maxNotes);

			
		}
		else if ((Input.GetKeyDown (num3)) && (other.gameObject.name == "Green Note(Clone)")) 
		{
			destroyNote3 = "yes";
			Notes.maxNotes-=1;
			Debug.Log (Notes.maxNotes);

			
		}
	}



}
