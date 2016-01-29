using UnityEngine;
using System.Collections;

public class Ranged : EnemyStates{

	private Enemy rangedEnemy;

	public void Enter(Enemy enemy){
		this.rangedEnemy = enemy;
	}
	public void Execute(){
		if (rangedEnemy.TargetCharacter != null) {
			rangedEnemy.moveEnemy ();
		} else {
			rangedEnemy.changeState(new Idle());
		}

	}
	public void Exit(){}
	public void OnTriggerEnter(Collider2D other){}

}
