using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	//uncomment this when needed
	//public AudioSource fx;
	public AudioSource gameMusic1;
	public AudioClip MainClip;
	public static SoundManager instance = null;
	/*
	float waitTime = 6.0f;
	float timeTime;
	*/

//	public float lowPitchVariation = 0.95f;
//	public float highPitchVariation = 1.06f;


	private static SoundManager sound_instance;
	public static SoundManager SoundInstance
	{
		get
		{
			if(sound_instance == null)
			{
				sound_instance = GameObject.FindObjectOfType<SoundManager>();
			}
			return sound_instance;
		}
		//this type of method is a singleton cant use it for enemies because its meant to be used on a single object
		//this one object can be accessed at all times
		// could be used for specific enemies 
		
	}

	void Awake () {

		if (instance == null) 
		{
			instance = this;
		} else if (instance != this) 
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	

		//PlayMusic (MainClip);
		StartCoroutine ("WaitAndPlay", 2.0f);

		/*
		if (timeTime >= waitTime) {
			StopCoroutine("WaitAndPlay");
		}
		*/
		//StopCoroutine (WaitAndPlay (5.0f));

	}



	public void PlayMusic(AudioClip clip)
	{
		gameMusic1.clip = clip;
		gameMusic1.Play ();
	}

	IEnumerator WaitAndPlay(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		gameMusic1.clip = MainClip;
		gameMusic1.Play ();

	}

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
