using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	//public properties
	public Rigidbody2D PlayerRigidBody{ get; set;}
	public bool IsAttacking{ get; set;}
	public bool IsJumping{ get; set;}
	public bool OnTheGround{ get; set;}

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
	private Animator playerAnimator;
	[SerializeField]
	private float speed;
	private bool facingRight;
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

	[SerializeField]
	private GameObject pinkFire;



	// Use this for initialization
	void Start () 
	{	
		facingRight = true;
		PlayerRigidBody = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator> ();
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
			playerAnimator.SetBool("landing", true);
		}

		if (!IsAttacking && (OnTheGround || moveInAir)) {
			PlayerRigidBody.velocity = new Vector2(horizontal * speed, PlayerRigidBody.velocity.y);
		}

		if(IsJumping && PlayerRigidBody.velocity.y == 0){
			PlayerRigidBody.AddForce(new Vector2(0,jumpForce));
		}
		playerAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
	}

//	private void handleAttacks()
//	{
//
//		if (isAttacking && isGrounded && !this.playerAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack_Mace")) {
//			playerAnimator.SetTrigger("attack");
//			playerRigidBody.velocity = Vector2.zero;
//		}
//
//		if (jumpAttack && !isGrounded && !this.playerAnimator.GetCurrentAnimatorStateInfo (1).IsName ("JumpAttack")) {
//			playerAnimator.SetBool("jumpAttack",true);
//		}
//
//		if (!jumpAttack && !isGrounded && !this.playerAnimator.GetCurrentAnimatorStateInfo (1).IsName ("JumpAttack")) {
//			playerAnimator.SetBool("jumpAttack",false);
//		}
//
//		//still attacks twice when lands, will fix 
//		if (!jumpAttack && isGrounded && !this.playerAnimator.GetCurrentAnimatorStateInfo (1).IsName ("JumpAttack")) {
//			playerAnimator.SetBool("jumpAttack",false);
//		}
//	}
	private void handleInput()
	{
		if (Input.GetKeyDown (KeyCode.Z)) {
			playerAnimator.SetTrigger("attacking");
		
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			playerAnimator.SetTrigger("jumping");
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			playerAnimator.SetTrigger("fireball");
			shootFire(0);
		}


	}
	private void flipPlayer(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;
			Vector3 playerScale = transform.localScale;
			playerScale.x *= -1;
			transform.localScale = playerScale;

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

	public void shootFire(int f)
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

		if (facingRight) {
			//Instantiate(pinkFire, (transform.position + new Vector3(result,0,0)), Quaternion.identity);
			GameObject tmp = (GameObject)Instantiate(pinkFire, transform.position, Quaternion.identity);
			tmp.GetComponent<Fireball>().Initialize(Vector2.right);
		} 
		else 
		{
			GameObject tmp2 =(GameObject)Instantiate(pinkFire, transform.position, Quaternion.Euler(new Vector3(0,0,180)));
			tmp2.GetComponent<Fireball>().Initialize(Vector2.left);


		}
	}


	private void HandleLayers()
	{
		if (!OnTheGround) {
			playerAnimator.SetLayerWeight(1,1);
		}else{
			playerAnimator.SetLayerWeight(1,0);
		}
	
	}

}
