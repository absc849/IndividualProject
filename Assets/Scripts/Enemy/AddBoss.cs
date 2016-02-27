using UnityEngine;
using System.Collections;

public class AddBoss : MonoBehaviour {

	[SerializeField]
	protected GameObject boss;
	[SerializeField]
	private BoxCollider2D barrier;
	private Vector3 startPos = new Vector3(154.52f,1.74f,0.0f);
	private float bossRotate = -180.0f;
	private bool canFightBoss;

	//make 4 boss variables 

	// Use this for initialization
	void Start () {

		//boss = GetComponent<GameObject> ();
		barrier = GetComponent<BoxCollider2D>();
		canFightBoss = false;


	}


//	// edit with if statement depending on the level to instantiate a boss, if level 1 then level 1 boss
//	void OnTriggerEnter2D(Collider2D o)
//	{
//		if (canFightBoss) {
//
//			if (o.gameObject.tag == "Player" && o.gameObject.transform.position.x < 151.9061) {
//	
//				//o.gameObject.GetComponent<Player> ().PlayerRigidBody.velocity.x = Vector2.zero;
////				Vector2 v = 
////				v.x = 0;
////				Player.PlayerInstance.PlayerRigidBody.velocity.x = v;
//
//			}
//		}
////		//if player gets passed the collision then activate 
////		//disable collision trigger 
////		// instantiate boss
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
			bossFight();
				barrier.isTrigger = false;
			}
		}
	}


	void bossFight()
	{
		if (canFightBoss == true) {
			Instantiate (boss, startPos, Quaternion.identity);
		}
//		canFightBoss = false;
	}

}











