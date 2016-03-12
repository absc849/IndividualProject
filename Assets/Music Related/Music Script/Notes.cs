using UnityEngine;
using System.Collections;

public class Notes : MonoBehaviour {

	private Rigidbody2D noteRigidBody;
	private Vector2 noteSpeed;

	// Use this for initialization
	void Start () {
		noteSpeed = new Vector2 (0, -10);
		noteRigidBody = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		//noteRigidBody.transform.Translate(Vector2.up * Time.deltaTime);
		noteRigidBody.velocity = noteSpeed * Time.deltaTime;


	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

//	void IsVisible()
//	{}

}
