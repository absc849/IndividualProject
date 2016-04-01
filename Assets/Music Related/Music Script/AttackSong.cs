using UnityEngine;
using System.Collections;

public class AttackSong : MonoBehaviour {

	private Transform songTarget;

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



}
