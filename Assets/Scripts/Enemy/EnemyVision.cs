﻿using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour {

	[SerializeField]
	private Enemy enemy;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == ("Player")) 
		{
			enemy.TargetCharacter = other.gameObject;
		}


	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == ("Player")) 
		{
			enemy.TargetCharacter = null;
		}
		
		
	}


}
