using UnityEngine;
using System.Collections;

public class ButtonFollow : MonoBehaviour {

	private Transform noteTarget;
	

	[SerializeField]
	private float xMax;
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;


	// Use this for initialization
	void Start () {
	
		noteTarget = GameObject.Find ("Player").transform;

	}
	


	// put this in another script

	void LateUpdate () 
	{
		transform.position = new Vector3 (Mathf.Clamp (noteTarget.position.x - 2.0f, xMin, xMax), Mathf.Clamp (noteTarget.position.y, yMin, yMax), 
		                                  transform.position.z);
	}

}
