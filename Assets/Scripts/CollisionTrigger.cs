using UnityEngine;
using System.Collections;

public class CollisionTrigger : MonoBehaviour {

	//private BoxCollider2D playerCollider;

	[SerializeField]
	private BoxCollider2D platCollider;

	[SerializeField]
	private BoxCollider2D platTrigger;
	// Use this for initialization
	void Start () {

		//playerCollider = GameObject.Find ("Player").GetComponent<BoxCollider2D> ();
		//Physics2D.IgnoreCollision(platCollider,platCollider, true);
		Physics2D.IgnoreCollision(platCollider,platTrigger, true);

	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player" || other.gameObject.tag == "Enemy") 
		{
			Physics2D.IgnoreCollision(platCollider,other,true);
		}

	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "Player" || other.gameObject.tag == "Enemy") 
		{
			Physics2D.IgnoreCollision(platCollider,other,false);
		}
	}

}
