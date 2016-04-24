using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	//uncomment this when needed
	//public AudioSource fx;
	public AudioSource gameMusic1;
	public static SoundManager instance = null;


//	public float lowPitchVariation = 0.95f;
//	public float highPitchVariation = 1.06f;

	void Awake () {

		if (instance == null) 
		{
			instance = this;
		} else if (instance != this) 
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	
	}


	/*
	public void PlayMusic()
	{
		gameMusic1
	}
	*/
	/*

	public void PlaySingleAudio(AudioClip clip)
	{
		fx.clip = clip;
		fx.Play ();
	}

	// params allow us to pass in a comma seperated list of the same time, specified by the parameter
	//plays random sound effects with variation
	public void RandomizeSfx(params AudioClip [] clips)
	{
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchVariation, highPitchVariation);
		fx.pitch = randomPitch;
		fx.clip = clips [randomIndex];
		fx.Play();

	}
	*/

}
