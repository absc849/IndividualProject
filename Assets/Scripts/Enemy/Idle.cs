using UnityEngine;
using System.Collections;

public class Idle : EnemyStates{

	private Enemy enemy;

	private float idleTimer;
	private float idleTimeSpan = 3f;

	public void Enter(Enemy enemy){
		this.enemy = enemy;
	}
	public void Execute(){
		idle ();
		Debug.Log("mans idling innit");
	}

	public void Exit(){}
	public void OnTriggerEnter(Collider2D other){}

	private void idle()
	{
		idleTimer += Time.deltaTime;

		enemy.GameAnimator.SetFloat ("speed", 0);

		if (idleTimer >= idleTimeSpan) {
			enemy.changeState(new Patrol());
		}
	}

}
