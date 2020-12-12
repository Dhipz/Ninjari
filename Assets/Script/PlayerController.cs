using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D playerRigidBody;
	private Collider2D playerCollider;

	public float moveSpeed;
	public float jumpPower;
	private bool isJump;
	private bool onGround;

	public LayerMask groundLayer;
	// Start is called before the first frame update
	void Start()
	{
		playerRigidBody = GetComponent<Rigidbody2D>();
		playerCollider = GetComponent<Collider2D>();
		isJump=false;
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
			isJump = true;
		}
		onGround = Physics2D.IsTouchingLayers(playerCollider, groundLayer);
	}

	// Update on fixed tick for physic
	void FixedUpdate()
	{
		if(isJump)
		{
			if(onGround)
			{
				playerRigidBody.velocity = new Vector2(moveSpeed, jumpPower);
			}
		}
		else
		{
			playerRigidBody.velocity = new Vector2(moveSpeed, playerRigidBody.velocity.y);
		}
		isJump = false;
	}
}
