using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D playerRigidBody;
	//private Collider2D playerCollider;

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;
	public float speedIncreaseLimit;
	private float speedIncreaseLimitStore;
	private float speedCounter;
	private float speedCounterStore;

	public float jumpPower;
	public float jumpAirTime;
	// private bool isJump;
	private bool isHoldJump;
	private bool onGround;
	private float currentAirTime;

	private bool stopFirstJump;
	private bool doubleJump;
	private bool isdoubleJump;

	public LayerMask groundLayer;
	public Transform groundCheck;
	public float groundCheckRadius;

	private Animator player_animation;

	public GameManager GM;

	public AudioSource jumpSound;
	public AudioSource deathSound;
	private AudioSource playSound;

	// Start is called before the first frame update
	void Start()
	{
		playerRigidBody = GetComponent<Rigidbody2D>();
		//playerCollider = GetComponent<Collider2D>();
		// isJump=false;
		player_animation = GetComponent<Animator>();
		speedCounter = speedIncreaseLimit;
		moveSpeedStore = moveSpeed;
		speedCounterStore = speedCounter;
		speedIncreaseLimitStore = speedIncreaseLimit;
		//stopJump = true;
		playSound = GameObject.Find("playsfx").GetComponent<AudioSource>();
		doubleJump = true;
		stopFirstJump = false;
		
	}

	// Update is called once per frame
	void Update()
	{
		// if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
		// 	isJump = true;
		// }
		if(Input.GetKey(KeyCode.Space)|| Input.GetMouseButton(0)){
			isHoldJump = true;
			jumpSound.Play();
		}
		else if(Input.GetKeyUp(KeyCode.Space)|| Input.GetMouseButtonUp(0)){
			isHoldJump = false;
			stopFirstJump = true;
			currentAirTime = 0;
		}
		//onGround = Physics2D.IsTouchingLayers(playerCollider, groundLayer);
		onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

		if(transform.position.x > speedCounter){
			speedCounter += speedIncreaseLimit;
			speedIncreaseLimit = speedIncreaseLimit*speedMultiplier;
			moveSpeed = moveSpeed*speedMultiplier;
		}
		if(!onGround && ((Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0)))){
			isdoubleJump = true;
		}
		else{
			isdoubleJump = false;
		}
		if(onGround){
			currentAirTime =jumpAirTime;
			doubleJump = true;
			stopFirstJump = false;
		}
		if(isHoldJump){
			stopFirstJump = true;
			if(currentAirTime > 0){
				playerRigidBody.velocity = new Vector2(moveSpeed, jumpPower);
				currentAirTime -= Time.deltaTime;
			}
		}
		if(stopFirstJump && !onGround){
			if(doubleJump && isdoubleJump){
				doubleJump = false;
				playerRigidBody.velocity = new Vector2(moveSpeed, jumpPower);
			}
		}
		else{

			playerRigidBody.velocity = new Vector2(moveSpeed, playerRigidBody.velocity.y);
			//stopJump = false;
			//doubleJump = true;
		}
		player_animation.SetFloat("speed", playerRigidBody.velocity.x);
		player_animation.SetBool("grounded", onGround);
	}

	// Update on fixed tick for physic
	void FixedUpdate()
	{
		// if(isJump){
		// 	if(onGround){
		// 		playerRigidBody.velocity = new Vector2(moveSpeed, jumpPower);
		// 	}
		// }
		// else{
		// 		playerRigidBody.velocity = new Vector2(moveSpeed, playerRigidBody.velocity.y);
		// }
		
		
		// isJump = false;

	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "killbox"){
			GM.RestartGame();
			moveSpeed = moveSpeedStore;
			speedCounter = speedCounterStore;
			speedIncreaseLimit = speedIncreaseLimitStore;
			deathSound.Play();
			player_animation.SetBool("death", other.gameObject.tag == "killbox");
		}
		/*else{
			playSound.Play();
		}*/
	}
}
