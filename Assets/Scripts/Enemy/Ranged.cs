using UnityEngine;
using System.Collections;

public class Ranged : EnemyStates{

	private Enemy rangedEnemy;

	private float attackTimer;
	private float attackWaitingTime = 2;
	private bool canDoSpecial;

	public void Enter(Enemy enemy){
		this.rangedEnemy = enemy;
	}
	public void Execute(){

		doSpecialAttack ();
		if (rangedEnemy.TargetCharacter != null) {

			rangedEnemy.moveEnemy ();
		} else {
			Debug.Log ("fuck this");
			rangedEnemy.changeState(new Idle());

		}

	}
	public void Exit(){
		Debug.Log("exiting");
	}
	public void OnTriggerEnter(Collider2D other){}

	private void doSpecialAttack()
	{
		attackTimer += Time.deltaTime;
		if (attackTimer >= attackWaitingTime) {
			canDoSpecial = true;
			attackTimer = 0;
		}
		
		if (canDoSpecial) {
			canDoSpecial = false;

			rangedEnemy.GameAnimator.SetTrigger("specialMove");
			Debug.Log ("attacking");
				//fix
		}

	}

}
