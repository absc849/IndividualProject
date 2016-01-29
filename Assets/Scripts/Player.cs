using UnityEngine;
using System.Collections;

public class Player : Character {
	//public properties
	public Rigidbody2D PlayerRigidBody{ get; set;}
	public bool IsJumping{ get; set;}
	public bool OnTheGround{ get; private set;}

	//animator will use this
	private static Player player_instance;
	public static Player PlayerInstance
	{
		get
		{
			if(player_instance == null)
			{
				player_instance = GameObject.FindObjectOfType<Player>();
			}
			return player_instance;
		}
		//this type of method is a singleton cant use it for enemies because its meant to be used on a single object
		//this one object can be accessed at all times
		// could be used for specific enemies 

	}

	[SerializeField] // we set the ground points in the inspector
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask whatIsGround;

	[SerializeField]
	private bool moveInAir;


	[SerializeField]
	private float jumpForce;





	// Use this for initialization
	public override void Start () 
	{	
		base.Start ();

		PlayerRigidBody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		handleInput ();
	}
	// Fixed Update is called once per frame
	void FixedUpdate() 
	{
		float horizontal = Input.GetAxis ("Horizontal");
		OnTheGround = onGround();

		handleMovement (horizontal);
		flipPlayer(horizontal);
		HandleLayers ();

	
	}


	private void handleMovement(float horizontal)
	{

		if (PlayerRigidBody.velocity.y < 0) {
			GameAnimator.SetBool("landing", true);
		}

		if (!IsAttacking && (OnTheGround || moveInAir)) {
			PlayerRigidBody.velocity = new Vector2(horizontal * speed, PlayerRigidBody.velocity.y);
		}

		if(IsJumping && PlayerRigidBody.velocity.y == 0){
			PlayerRigidBody.AddForce(new Vector2(0,jumpForce));
		}
		GameAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
	}

//	private void handleAttacks()
//	{
//
//		if (isAttacking && isGrounded && !this.GameAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack_Mace")) {
//			GameAnimator.SetTrigger("attack");
//			playerRigidBody.velocity = Vector2.zero;
//		}
//
//		if (jumpAttack && !isGrounded && !this.GameAnimator.GetCurrentAnimatorStateInfo (1).IsName ("JumpAttack")) {
//			GameAnimator.SetBool("jumpAttack",true);
//		}
//
//		if (!jumpAttack && !isGrounded && !this.GameAnimator.GetCurrentAnimatorStateInfo (1).IsName ("JumpAttack")) {
//			GameAnimator.SetBool("jumpAttack",false);
//		}
//
//		//still attacks twice when lands, will fix 
//		if (!jumpAttack && isGrounded && !this.GameAnimator.GetCurrentAnimatorStateInfo (1).IsName ("JumpAttack")) {
//			GameAnimator.SetBool("jumpAttack",false);
//		}
//	}
	private void handleInput()
	{
		if (Input.GetKeyDown (KeyCode.Z)) {
			GameAnimator.SetTrigger("attacking");
		
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameAnimator.SetTrigger("jumping");
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			GameAnimator.SetTrigger("fireball");
			//shootFire(0);
		}


	}
	private void flipPlayer(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			changeDirection();
		}
	}



	private bool onGround()
	{
		if (PlayerRigidBody.velocity.y <= 0) // if less than 0 then not grounded
		{ 
			foreach (Transform point in groundPoints) { 
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) 
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public override void doSpecialAttack(int v)
	{
		/*
		float result = (float)0.5;
		if (float.IsPositiveInfinity(result))
		{
			result = float.MaxValue;
		} else if (float.IsNegativeInfinity(result))
		{
			result = float.MinValue;
		}
		*/
		// f = 1 - in the air - 0 - on the ground, prevents two fireballs being shot at once
		if(!OnTheGround && v == 1 || OnTheGround && v == 0)
		{
			base.doSpecialAttack(v);
		}



	}


	private void HandleLayers()
	{
		if (!OnTheGround) {
			GameAnimator.SetLayerWeight(1,1);
		}else{
			GameAnimator.SetLayerWeight(1,0);
		}
	
	}

}
