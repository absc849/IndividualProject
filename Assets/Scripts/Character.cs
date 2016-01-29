using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	public bool IsAttacking{ get; set;}
	//protected Animator GameAnimator;
	public Animator GameAnimator{ get; set;}
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
		if (facingRight) {
			GameObject tmp = (GameObject)Instantiate(magicSpell, spellPosition.position, Quaternion.identity);
			tmp.GetComponent<Fireball>().Initialize(Vector2.right);
		} 
		else 
		{
			GameObject tmp2 =(GameObject)Instantiate(magicSpell, spellPosition.position, Quaternion.Euler(new Vector3(0,0,180)));
			tmp2.GetComponent<Fireball>().Initialize(Vector2.left);
			
		}
	}

}
