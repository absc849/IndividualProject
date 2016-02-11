using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))] 
// this adds the rigid body 

public class Fireball : MonoBehaviour {

	//change to special attack
	[SerializeField]
	private float attackSpeed;
	private Rigidbody2D fireRigidBody;
	private Vector2 attackDirection;

	// Use this for initialization
	void Start () {
		fireRigidBody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		fireRigidBody.velocity = attackDirection * attackSpeed;
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
