using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//attack loops fix when you get home
	private Rigidbody2D playerRigidBody;
	private Animator playerAnimator;
	[SerializeField]
	private float speed;
	private bool facingRight;
	private bool isAttacking;
	[SerializeField] // we set the ground points in the inspector
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask whatIsGround;

	[SerializeField]
	private bool airControl;
	private bool isGrounded;
	private bool jump;

	[SerializeField]
	private float jumpForce;
	// Use this for initialization
	void Start () 
	{	
		facingRight = true;
		playerRigidBody = GetComponent<Rigidbody2D>();
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
		isGrounded = IsGrounded();

		handleMovement (horizontal);
		flipPlayer(horizontal);
		handleAttacks ();
		resetValues();

	
	}


	private void handleMovement(float horizontal)
	{


		if (isGrounded && jump) 
		{
			isGrounded = false;
			playerRigidBody.AddForce(new Vector2(0,jumpForce));
		}
		//if the player animator isnt attacking, layer 0 because base layer is layer 0 
		if (!playerAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack_Mace") && (isGrounded || airControl)) 
		{
			playerRigidBody.velocity = new Vector2 (horizontal * speed, playerRigidBody.velocity.y);

		}
		playerAnimator.SetFloat ("speed", Mathf.Abs(horizontal)); // returns positive value not negative
	}

	private void handleAttacks()
	{

		if (isAttacking && !this.playerAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack_Mace")) {
			playerAnimator.SetTrigger("attack");
			playerRigidBody.velocity = Vector2.zero;
		}
	}
	private void handleInput()
	{
		if (Input.GetKeyDown (KeyCode.Z)) {
			isAttacking = true;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
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

	private void resetValues()
	{
		isAttacking = false;
		jump = false;
	}

	private bool IsGrounded()
	{
		if (playerRigidBody.velocity.y <= 0) // if less than 0 then not grounded
		{ 
			foreach (Transform point in groundPoints) { 
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						return true;
					}
				}
			}
		}
		return false;
	}


}
