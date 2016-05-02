using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponCollider : MonoBehaviour {
	
	[SerializeField]
	private List<string> targetTags;
	public static bool hasCollided;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (targetTags.Contains(other.tag))
		{
			hasCollided = true;
			GetComponent<Collider2D>().enabled = false;
		}


	}

	void onTriggerExit2D()
	{
		hasCollided = false;
	}
}
