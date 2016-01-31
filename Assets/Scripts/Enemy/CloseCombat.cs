using UnityEngine;
using System.Collections;

public class CloseCombat : EnemyStates 
{
	private Enemy meleeEnemy;
	private float meleeAttackTimer;
	private float meleeAttackWaitingTime = 3;
	private bool canStartCloseCombat = true;


	public void Enter(Enemy enemy){
		this.meleeEnemy = enemy;
	}
	public void Execute(){
		doMeleeAttack ();

	}
	public void Exit(){}
	public void OnTriggerEnter(Collider2D other){}

	private void doMeleeAttack()
	{
		meleeAttackTimer += Time.deltaTime;
		if (meleeAttackTimer >= meleeAttackWaitingTime) {
			canStartCloseCombat = true;
			meleeAttackTimer = 0;
		}
		
		if (canStartCloseCombat) {
			canStartCloseCombat = false;
			
			meleeEnemy.GameAnimator.SetTrigger("attacking");
		}
		
	}
}
