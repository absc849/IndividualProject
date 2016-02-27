using UnityEngine;
using System.Collections;

public class Patrol : EnemyStates {

	private Enemy patrollingEnemy;
	private float patrolTimer;
	private float patrolTimeSpan;

	public void Enter(Enemy enemy){
		patrolTimeSpan = Random.Range (2, 8);
		this.patrollingEnemy = enemy;
	}
	public void Execute(){
		Debug.Log("im on patrol");
		patrol ();
		patrollingEnemy.moveEnemy();
		if (patrollingEnemy.TargetCharacter != null && patrollingEnemy.inSpecialAttackRange) {
			patrollingEnemy.changeState (new Ranged ());
		} 

	}
	public void Exit(){}
	public void OnTriggerEnter(Collider2D other)
	{
		/*
		if (other.tag == "TurningPoint") {
			Debug.Log("i hit the point D:");
			patrollingEnemy.changeDirection();

		}
		*/

		if (other.tag == "FireBall" || other.tag == "Mace") 
		{
			patrollingEnemy.TargetCharacter = Player.PlayerInstance.gameObject;
		}
	}

	private void patrol()
	{
		patrolTimer+= Time.deltaTime;
		

		if (patrolTimer >= patrolTimeSpan) {
			patrollingEnemy.changeState(new Idle());
		}
	}


}
