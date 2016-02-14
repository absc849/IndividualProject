using UnityEngine;
using System.Collections;

public class Idle : EnemyStates{

	private Enemy enemy;

	private float idleTimer;
	private float idleTimeSpan = 2f;

	public void Enter(Enemy enemy){
		this.enemy = enemy;
	}
	public void Execute(){
		Debug.Log("im idle now");
		idle ();
		Debug.Log("just idling ");
		if (enemy.TargetCharacter != null) {
			enemy.changeState(new Patrol());
		}
	}

	public void Exit(){}
	public void OnTriggerEnter(Collider2D other){
		if (other.tag == "FireBall" || other.tag == "Mace") 
		{
			enemy.TargetCharacter = Player.PlayerInstance.gameObject;
		}
	}

	private void idle()
	{
		idleTimer += Time.deltaTime;

		enemy.GameAnimator.SetFloat ("speed", 0);

		if (idleTimer >= idleTimeSpan) {
			idleTimer = 0;
			enemy.changeState(new Patrol());
		}
	}

}
