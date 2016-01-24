using UnityEngine;
using System.Collections;

public class CollisionTrigger : MonoBehaviour {

	private BoxCollider2D playerCollider;

	[SerializeField]
	private BoxCollider2D platCollider;

	[SerializeField]
	private BoxCollider2D platTrigger;
	// Use this for initialization
	void Start () {

		playerCollider = GameObject.Find ("Player").GetComponent<BoxCollider2D> ();
		Physics2D.IgnoreCollision(platCollider,platCollider, true);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") 
		{
			Physics2D.IgnoreCollision(platCollider,playerCollider,true);
		}

	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "Player") 
		{
			Physics2D.IgnoreCollision(platCollider,playerCollider,false);
		}
	}

}
