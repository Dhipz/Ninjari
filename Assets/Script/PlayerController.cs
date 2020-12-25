using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D playerRigidBody;
	//private Collider2D playerCollider;

	public float moveSpeed;
	public float speedMultiplier;
	public float speedIncreaseLimit;
	private float speedCounter;

	public float jumpPower;
	public float jumpAirTime;
	// private bool isJump;
	private bool isHoldJump;
	private bool onGround;
	private float currentAirTime;

	public LayerMask groundLayer;
	public Transform groundCheck;
	public float groundCheckRadius;

	private Animator player_animation;

	// Start is called before the first frame update
	void Start()
	{
		playerRigidBody = GetComponent<Rigidbody2D>();
		//playerCollider = GetComponent<Collider2D>();
		// isJump=false;
		player_animation = GetComponent<Animator>();
		speedCounter = speedIncreaseLimit;
	}

	// Update is called once per frame
	void Update()
	{
		// if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
		// 	isJump = true;
		// }
		if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)){
			isHoldJump = true;
		}
		else if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)){
			isHoldJump = false;
			currentAirTime = 0;
		}
		//onGround = Physics2D.IsTouchingLayers(playerCollider, groundLayer);
		onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

		if(transform.position.x > speedCounter){
			speedCounter += speedIncreaseLimit;
			speedIncreaseLimit = speedIncreaseLimit*speedMultiplier;
			moveSpeed = moveSpeed*speedMultiplier;
		}
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
		
		if(onGround){
			currentAirTime =jumpAirTime; 
		}
		if(isHoldJump){
			if(currentAirTime > 0){
				playerRigidBody.velocity = new Vector2(moveSpeed, jumpPower);
				currentAirTime -= Time.deltaTime;
			}
		}
		else{

			playerRigidBody.velocity = new Vector2(moveSpeed, playerRigidBody.velocity.y);
		}
		// isJump = false;

		player_animation.SetFloat("speed", playerRigidBody.velocity.x);
		player_animation.SetBool("grounded", onGround);
	}
}
