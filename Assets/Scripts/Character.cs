using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour {
	[SerializeField]
	protected int health;
	[SerializeField]
	private EdgeCollider2D weaponCollider;
	


	public EdgeCollider2D getWeaponCollider
	{
		get{
			return weaponCollider;
		}
	}

	public abstract void CharacterDemise ();

	[SerializeField]
	private List<string> attackSources;


	public abstract bool isDead{ get;}
	public bool IsAttacking{ get; set;}
	//protected Animator GameAnimator;
	public Animator GameAnimator{ get; set;}
	public bool TakingDamage{ get; set;}
	[SerializeField]
	protected float speed;
	protected bool facingRight;
	[SerializeField]
	protected GameObject magicSpell;
	
	[SerializeField]
	protected Transform spellPosition;
	// Use this for initialization
	public virtual void Start () {

		facingRight = true;
		GameAnimator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeDirection()
	{
		facingRight = !facingRight;
		Vector3 charScale = transform.localScale;
		charScale.x *= -1;
		transform.localScale = charScale;

	}

	public virtual void doSpecialAttack(int v)
	{
		Debug.Log ("doin special");
		if (facingRight) {
			GameObject tmp = (GameObject)Instantiate(magicSpell, spellPosition.position, Quaternion.identity);
			Debug.Log ("yo");

			tmp.GetComponent<SpecialAttack>().Initialize(Vector2.right);
		} 
		else 
		{
			GameObject tmp2 =(GameObject)Instantiate(magicSpell, spellPosition.position, Quaternion.Euler(new Vector3(0,0,180)));
			Debug.Log ("yo");

			tmp2.GetComponent<SpecialAttack>().Initialize(Vector2.left);
			
		}
	}

	public abstract IEnumerator GetsHurt ();

	public void MeleeAttack()
	{
//		weaponCollider.enabled = !weaponCollider.enabled;
		getWeaponCollider.enabled = true;
//
//			Vector3 tmpPos = weaponCollider.transform.position;
//			weaponCollider.transform.position = new Vector3 (weaponCollider.transform.position.x + 0, 01, weaponCollider.transform.position.y);
//			weaponCollider.transform.position = tmpPos;

	//	weaponCollider.enabled = false;

	}

	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		//make another list with enemy vision and make if statement if the tag does not equal to the vision then do the next thing	
		if (attackSources.Contains(other.tag)) {
			StartCoroutine(GetsHurt());
		}
	}


	
}
