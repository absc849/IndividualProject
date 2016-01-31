using UnityEngine;
using System.Collections;

public class Patrol : EnemyStates {

	private Enemy patrollingEnemy;
	private float patrolTimer;
	private float patrolTimeSpan = 8f;

	public void Enter(Enemy enemy){
		this.patrollingEnemy = enemy;
	}
	public void Execute(){
		Debug.Log("im on patrol");
		patrol ();
		patrollingEnemy.moveEnemy();
		if (patrollingEnemy.TargetCharacter != null) {
			patrollingEnemy.changeState (new Ranged ());
		} 
	}
	public void Exit(){}
	public void OnTriggerEnter(Collider2D other)
	{
		if (other.tag == "TurningPoint") {
			Debug.Log("i hit the point D:");
			patrollingEnemy.changeDirection();

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
