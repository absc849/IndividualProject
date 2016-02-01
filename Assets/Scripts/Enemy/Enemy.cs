﻿using UnityEngine;
using System.Collections;

public class Enemy : Character {

	private EnemyStates currentState;
	[SerializeField]
	private float meleeRange;

	[SerializeField]
	private float specialAttackRange;
	public GameObject TargetCharacter{ get; set;}

	// Use this for initialization
	public override void Start () {
	
		base.Start ();
		changeState (new Idle ());
	}
	
	// Update is called once per frame
	void Update () {


		if (!isDead) {
			if(!TakingDamage){
				currentState.Execute ();
			}
			lookForCharacter ();
		}

	
	}

	public bool inMeleeRange
	{
		get {
			if(TargetCharacter !=null)
			{
				return Vector2.Distance(transform.position, TargetCharacter.transform.position) <= meleeRange;
			}else{
				return false;
			}
		}
	}

	public bool inSpecialAttackRange
	{
		get {
			if(TargetCharacter !=null)
			{
				return Vector2.Distance(transform.position, TargetCharacter.transform.position) <= specialAttackRange;
			}else{
				return false;
			}
		}
	}


	private void lookForCharacter()
	{
		if (TargetCharacter != null) 
		{
			float xDirection = TargetCharacter.transform.position.x - transform.position.x;
			if ( xDirection < 0 && facingRight || xDirection > 0 && !facingRight)
			{
				changeDirection();
			}
		}
	}
	public override void  OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D (other);
		currentState.OnTriggerEnter (other);
	}
	public Vector2 getDirection()
	{
		if (facingRight) {
			return Vector2.right;
		} else {
			return Vector2.left;
		}
	}

	public void changeState(EnemyStates newState)
	{
		Debug.Log("changing state");
		if (currentState != null)
		{
			currentState.Exit();
		}

		currentState = newState;

		currentState.Enter (this);
	}

	public void moveEnemy()
	{
		//edit if statement so enemy 1 can still move
		Debug.Log("moving");
		if(!IsAttacking)
		{
			GameAnimator.SetFloat ("speed", 1);
			//multiplying it by the time makes sure that no matter what computer you use the enemy is at a normal speed
			transform.Translate (getDirection () * (speed * Time.deltaTime));
		 }


	}

	public override IEnumerator GetsHurt()
	{
		health -= 10;
		if (!isDead) {
			GameAnimator.SetTrigger ("damage");
		} else {
			GameAnimator.SetTrigger("death");
			yield return null;
		}

	}

	public override bool isDead
	{
		get{
			return health <=0;
			Destroy(this);
		}
	}
}
