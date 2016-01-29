using UnityEngine;
using System.Collections;

public class Enemy : Character {

	private EnemyStates currentState;
	public GameObject TargetCharacter{ get; set;}
	// Use this for initialization
	public override void Start () {
	
		base.Start ();
		changeState (new Idle ());
	}
	
	// Update is called once per frame
	void Update () {

		currentState.Execute ();
		lookForCharacter ();

	
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
			// fix
		}
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("i hit the point");

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
		if (currentState != null)
		{
			currentState.Exit();
		}

		currentState = newState;

		currentState.Enter (this);
	}

	public void moveEnemy()
	{
		GameAnimator.SetFloat ("speed", 1);
		//multiplying it by the time makes sure that no matter what computer you use the enemy is at a normal speed
		transform.Translate (getDirection () * (speed * Time.deltaTime));

	}
}
