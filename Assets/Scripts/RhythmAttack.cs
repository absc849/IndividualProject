﻿using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))] 


public class RhythmAttack : MonoBehaviour {


	//change to rhythm attack
	[SerializeField]
	private float attackSpeed;
	private Rigidbody2D rhythmRigidBody;
	private Vector2 attackDirection;
	public static bool rhythmCollided;

	
	// Use this for initialization
	void Start () {
		rhythmCollided = false;
		rhythmRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate()
	{
		rhythmRigidBody.velocity = attackDirection * attackSpeed;
	}
	
	
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss") {
			rhythmCollided = true;
			Destroy (gameObject);
		}
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

