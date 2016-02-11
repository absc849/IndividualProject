﻿using UnityEngine;
using System.Collections;

public class IgnoreCollisions : MonoBehaviour {

	[SerializeField]
	private Collider2D other;

	
	private void Awake () {
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other, true);
	
	}
}
