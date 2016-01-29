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
		Debug.Log("mans on patrol");
		patrol ();
		patrollingEnemy.moveEnemy();
	}
	public void Exit(){}
	public void OnTriggerEnter(Collider2D other)
	{
		if (other.tag == "TurningPoint") {
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
