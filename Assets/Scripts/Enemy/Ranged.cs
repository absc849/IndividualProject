﻿using UnityEngine;
using System.Collections;

public class Ranged : EnemyStates{

	private Enemy rangedEnemy;

	private float attackTimer;
	private float attackWaitingTime = 3;
	private bool canDoSpecial = true;
	//this used to be empty if this fails

	public void Enter(Enemy enemy){
		this.rangedEnemy = enemy;
	}
	public void Execute(){
		Debug.Log ("I SEE YOU");
		doSpecialAttack ();
		if (rangedEnemy.inMeleeRange) 
		{
			rangedEnemy.changeState(new CloseCombat());
		}
		else if (rangedEnemy.TargetCharacter != null) {

			rangedEnemy.moveEnemy ();
		} else {
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
