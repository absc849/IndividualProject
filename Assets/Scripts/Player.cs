﻿using UnityEngine;
using System.Collections;


public delegate void DeathHandler();

public class Player : Character {
	//public properties
	public  Rigidbody2D PlayerRigidBody{ get; set;}
	public bool IsJumping{ get; set;}
	public bool OnTheGround{ get; private set;}
	private bool tempImmortal = false;
	public bool usingRhythm { get; set;}

	public bool canFightBoss{ get; set;} 


	[SerializeField]
	protected GameObject RhythmBlade;
	protected float yPos;
	protected float xPos;
	protected float endGameTimer;

	//private Vector3 startPos = new Vector3(143.71f,-1.75f,0.0f);
	//private Vector3 startPos = new Vector3(79.5f,-1.75f,0.0f);
	private Vector3 startPos = new Vector3(-4.5f,0.0f,0.0f);
	//private Vector3 startPos = new Vector3(217.4f,0.0f,0.0f);
	
	[SerializeField]
	private float immortalityTime;

	[SerializeField]
	protected int spawnHealth;

	[SerializeField]
	protected int Life;

	public event DeathHandler Death;
	private SpriteRenderer playerRenderer;
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
	protected Transform rhythmAttackPosition;

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
		usingRhythm = false;
		endGameTimer = 0;


		transform.position = startPos;
		playerRenderer = GetComponent<SpriteRenderer> ();
		PlayerRigidBody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{

		if (!TakingDamage && !isDead) {
			if(transform.position.y <= -7.15)
			{
				CharacterDemise();
			}
			handleInput ();
			yPos = rhythmAttackPosition.position.y;
			xPos = rhythmAttackPosition.position.x;

		}
		if (isDead && Life <= 0) {
			
			//SoundManager.SoundInstance.PauseMusic();
			Application.LoadLevel(1);
			
			
		}

		if (Enemy.bossIsDead == true) {
			endGameTimer += Time.deltaTime;
			Debug.Log (endGameTimer);
			if(endGameTimer > 4.5){
				Application.LoadLevel(1);
			}
		}
	}
	// Fixed Update is called once per frame
	void FixedUpdate() 
	{
		if (!TakingDamage && !isDead) {
			float horizontal = Input.GetAxis ("Horizontal");
			OnTheGround = onGround();
			
			handleMovement (horizontal);
			flipPlayer(horizontal);
			HandleLayers ();
		}
	
	

	}



	public void doRhythmAttack()
	{
		// put in int v if this doesnt work
		if (facingRight) {
			if(Player.PlayerInstance.usingRhythm == true){
				for(int i = 0; i < 6; i++)
				{
					
					GameObject tmpR = (GameObject)Instantiate(RhythmBlade, new Vector3(xPos,(yPos + (1 + i)), 0), Quaternion.identity);
					tmpR.GetComponent<RhythmAttack>().Initialize(Vector2.right);
					
				}
			}
		} 
		else 
		{
			if(Player.PlayerInstance.usingRhythm == true){
				for(int i = 0; i < 6; i++)
				{
					
					GameObject tmpL = (GameObject)Instantiate(RhythmBlade, new Vector3(xPos,(yPos + (1+ i)), 0), Quaternion.Euler(new Vector3(0,0,180)));
					tmpL.GetComponent<RhythmAttack>().Initialize(Vector2.left);
					
				}
				
			}

			
			
		}
	}



	private void handleMovement(float horizontal)
	{

		if (PlayerRigidBody.velocity.y < 0) {
			GameAnimator.SetBool("landing", true);
		}

		if (!IsAttacking && (OnTheGround || moveInAir)) {
			PlayerRigidBody.velocity = new Vector2(horizontal * speed, PlayerRigidBody.velocity.y);
		}

		if(IsJumping && !IsAttacking && PlayerRigidBody.velocity.y == 0){
			PlayerRigidBody.AddForce(new Vector2(0,jumpForce));
		}
		GameAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
	}

	//posibly make a function that sets the trigger to spawn the boss when x position is in a certain point???

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
		if (Input.GetKeyDown (KeyCode.C) && !IsJumping) {

			GameAnimator.SetTrigger("rhythmAttack");
			usingRhythm = true;
			Debug.Log (usingRhythm);
			AttackSong.NoteButtons.SetActive(true);

			//shootFire(0);
		}


	}
	private void flipPlayer(float horizontal)
	{
		if (!IsAttacking) {
			if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
				changeDirection ();
			}
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

	private IEnumerator showImmortality()
	{
		// also add to boss character
		while (tempImmortal) {
			playerRenderer.enabled = false;
			yield return new WaitForSeconds(0.1f);
			playerRenderer.enabled = true;
			yield return new WaitForSeconds(0.1f);

		}
	}

	public override IEnumerator GetsHurt()
	{
		// add this to boss characters 
		if (!tempImmortal) {
			health -= 10;
			if (!isDead) {
				GameAnimator.SetTrigger ("damage");
				Debug.Log ("ouch");
				tempImmortal = true;
				StartCoroutine(showImmortality());
				yield return new WaitForSeconds(immortalityTime);
				tempImmortal = false;
			} else {
				GameAnimator.SetLayerWeight(1,0);
				GameAnimator.SetTrigger("death");
			}
		}
	
	}

	public void triggerDeath()
	{
		if (Death != null) 
		{
			Death();
		
		}
	}

	public override bool isDead
	{
		get{
			if(health <= 0)
			{
				Life -= 1;

				triggerDeath();

			}
			return health <=0;
		}
	}

	public override void CharacterDemise()
	{
		Life -= 1;
		PlayerRigidBody.velocity = Vector2.zero;
		GameAnimator.SetTrigger("idle");
		health = spawnHealth;
		transform.position = startPos;
		if (AddBoss.canFightBoss == true) {
			//change this when editing level
			transform.position = new Vector3 (226, -1.55f, 0);
		
		} else {
			transform.position = startPos;

		}

		if(Life <= 0)
		{
			//SoundManager.SoundInstance.PauseMusic();
			Application.LoadLevel(1);
			
		}
	}
}
