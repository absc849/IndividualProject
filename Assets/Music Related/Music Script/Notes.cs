using UnityEngine;
using System.Collections;

public class Notes : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3(0,-5,0) * Time.deltaTime);


	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

	void IsVisible()
	{}

}
