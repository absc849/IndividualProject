using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponCollider : MonoBehaviour {
	
	[SerializeField]
	private List<string> targetTags;

	void OnTriggerEnter(Collider2D other)
	{
		if (targetTags.Contains(other.tag))
		{
			GetComponent<Collider2D>().enabled = false;
		}


	}
}
