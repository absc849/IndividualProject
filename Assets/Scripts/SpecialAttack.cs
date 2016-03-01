using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))] 
// this adds the rigid body 

public class SpecialAttack : MonoBehaviour {
	
	//change to special attack
	[SerializeField]
	private float attackSpeed;
	private Rigidbody2D specialRigidBody;
	private Vector2 attackDirection;
	
	// Use this for initialization
	void Start () {
		specialRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate()
	{
		specialRigidBody.velocity = attackDirection * attackSpeed;
	}

	void OnCollisionEnter()
	{
		Destroy (gameObject);
	}
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
	
	public void Initialize(Vector2 direction)
	{
		this.attackDirection = direction;
	}
}
