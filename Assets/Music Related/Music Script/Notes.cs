using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))] 

public class Notes : MonoBehaviour {

	private Rigidbody2D noteRigidBody;
	private Vector2 noteSpeed;
	private Transform attackNoteTarget;

	public static int maxNotes = 10;

	/*
	private float bpm1 = 111;
	private float crotchet;
	private float offset = 0.2;
	private float songposition;
	*/


	float tempAttackNotePos = 0;


	// Use this for initialization
	void Start () {

		//if (Player.PlayerInstance.usingRhythm == true) {

			noteSpeed = new Vector2 (0, -10);
			noteRigidBody = GetComponent<Rigidbody2D> ();
			/*
		note1Target = GameObject.Find ("Red Note Button").transform;
		note2Target = GameObject.Find ("Blue Note Button").transform;
		note3Target = GameObject.Find ("Green Note Button").transform;
	*/
	
			attackNoteTarget = GameObject.Find ("NoteButtons").transform;


			if (gameObject.name == "Red Note(Clone)") {
				GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -1, 0);
			}
			if (gameObject.name == "Blue Note(Clone)") {
				GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -1, 0);
			}
			if (gameObject.name == "Green Note(Clone)") {
				GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -1, 0);
			}
	//	}

	}
	
	// Update is called once per frame
	void Update () {

		//if (Player.PlayerInstance.usingRhythm == true) {

			tempAttackNotePos = attackNoteTarget.position.y;


			if ((AttackSong.destroyNote1 == "yes") && (gameObject.name == "Red Note(Clone)") && (transform.position.y < tempAttackNotePos)) {
				Destroy (gameObject);
				//instantiate destroy animation use code here and replace anim with the animation name
				//Instantiate(anim,transform.position,anim.rotation)
				AttackSong.correctNotes += 1;
				AttackSong.destroyNote1 = "no";
			} else if ((AttackSong.destroyNote2 == "yes") && (gameObject.name == "Blue Note(Clone)") && (transform.position.y < tempAttackNotePos)) {
				Destroy (gameObject);
				//instantiate destroy animation
				AttackSong.correctNotes += 1;
				AttackSong.destroyNote2 = "no";


			} else if ((AttackSong.destroyNote3 == "yes") && (gameObject.name == "Green Note(Clone)") && (transform.position.y < tempAttackNotePos)) {
				Destroy (gameObject);
				//instantiate destroy animation
				AttackSong.correctNotes += 1;
				AttackSong.destroyNote3 = "no";


			}


		//}
	}

	void OnTriggerEnter2D()
	{
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 0);
	}



	void OnTriggerExit2D()
	{
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
		//play sound effect 
		Destroy (gameObject, 0.35f);
		maxNotes--;


	}



	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}



//	void IsVisible()
//	{}

}
