using UnityEngine;
using System.Collections;

public class AddBoss : MonoBehaviour {

	[SerializeField]
	protected GameObject boss;
	[SerializeField]
	private BoxCollider2D barrier;
	private Vector3 startPos = new Vector3(235.46f,-0.57f,0.0f);
	//private float bossRotate = -180.0f;
	public static bool canFightBoss;

	//make 4 boss variables 

	// Use this for initialization
	void Start () {

		//boss = GetComponent<GameObject> ();
		barrier = GetComponent<BoxCollider2D>();
		canFightBoss = false;


	}


////	// edit with if statement depending on the level to instantiate a boss, if level 1 then level 1 boss
//	void OnTriggerEnter2D(Collider2D o)
//	{
//		if (o.gameObject.tag == "Enemy") {
//			barrier.isTrigger = true;
//		}
//	}



//	void OnTriggerStay2D(Collider2D o)
//	{
//		if (o.gameObject.tag == "Player") {
//			canFightBoss = false;
//		}
//	}


	void OnTriggerExit2D(Collider2D o)
	{
		if (o.gameObject.tag == "Player") {
			//Physics2D.IgnoreCollision (barrier, o, false);
			if(!canFightBoss){
			canFightBoss = true;
			//bossFight();
				barrier.isTrigger = false;
			}
		}

	}


	/*

	void bossFight()
	{
		if (canFightBoss == true) {
			Instantiate (boss, startPos, Quaternion.identity);
		//	boss.gameObject.GetComponent<Enemy>().
		}
//		canFightBoss = false;
	}
*/
}











