using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))] 

/*
 * 
	[SerializeField]
	public GameObject[] notes;

	float tempPos;


	// Use this for initialization
	void Start () {
		songTarget = GameObject.Find ("NoteButtons").transform;
		//tempPos = songTarget.position.x - 6.7f;

	}
	
	// Update is called once per frame
	void Update () {
	
		//songTarget = GameObject.Find ("NoteButtons").transform;
		tempPos = songTarget.position.x - 4.65f;


		//foreach(GameObject i in notes)
		for (int i = 0; i < notes.Length; i++) {
			Instantiate (notes [i], new Vector3 ((tempPos + i), (songTarget.position.y + 4), 0), Quaternion.identity);
		}


	}
 * */
public class Notes : MonoBehaviour {

	private Rigidbody2D noteRigidBody;
	private Vector2 noteSpeed;

	/*
	public Transform burst;
	private Transform note1Target;
	private Transform note2Target;
	private Transform note3Target;
	float tempPos1;
	float tempPos2;
	float tempPos3;
*/


	// Use this for initialization
	void Start () {

		noteSpeed = new Vector2 (0, -10);
		noteRigidBody = GetComponent<Rigidbody2D> ();
		/*
		note1Target = GameObject.Find ("Red Note Button").transform;
		note2Target = GameObject.Find ("Blue Note Button").transform;
		note3Target = GameObject.Find ("Green Note Button").transform;
	*/
	


		if (gameObject.name == "Red Note(Clone)")
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -1, 0);
		}
		if (gameObject.name == "Blue Note(Clone)")
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -1, 0);
		}
		if (gameObject.name == "Green Note(Clone)")
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, -1, 0);
		}


	}
	
	// Update is called once per frame
	void Update () {

		if ((AttackSong.destroyNote1 == "yes") && (gameObject.name == "Red Note(Clone)")) 
		{
			Destroy (gameObject);
			//instantiate destroy animation use code here and replace anim with the animation name
			//Instantiate(anim,transform.position,anim.rotation)
		}
		else if ((AttackSong.destroyNote2 == "yes") && (gameObject.name == "Blue Note(Clone)")) 
		{
			Destroy (gameObject);
			//instantiate destroy animation
		}
		else if ((AttackSong.destroyNote3 == "yes") && (gameObject.name == "Green Note(Clone)")) 
		{
			Destroy (gameObject);
			//instantiate destroy animation
		}



	}

	void OnTriggerEnter2D()
	{
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 0);
	}

	void OnTriggerExit2D()
	{
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1);
		Destroy (gameObject, 0.35f);

	}


	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}



//	void IsVisible()
//	{}

}
