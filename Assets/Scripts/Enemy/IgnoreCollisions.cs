using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class IgnoreCollisions : MonoBehaviour {

	[SerializeField]
	private Collider2D other;
	[SerializeField]
	private Collider2D ownCollider;



//	if (attackSources.Contains(other.tag)) {
//		StartCoroutine(GetsHurt());
//	}
	private void Awake () {
	
			Physics2D.IgnoreCollision (GetComponent<Collider2D> (), other, true);
		Physics2D.IgnoreCollision(GetComponent<Collider2D> (), ownCollider, true);

	}
}
