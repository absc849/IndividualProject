using UnityEngine;
using System.Collections;

public interface EnemyStates
{

	void Enter(Enemy enemy);
	void Execute();
	void Exit();
	void OnTriggerEnter(Collider2D other);



}
