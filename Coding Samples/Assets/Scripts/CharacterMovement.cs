using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
	private CharacterController myController;
	private Vector3 myV3Movement;
	public float mySpeed = 1f;
	public float myGravity = -9.81f;
	public bool canJump;
	public int maxJumpCount;

	void Start()
	{
	    myController = GetComponent<CharacterController>();
	}


	void Update()
	{
	    if(Input.GetKeyDown(KeyCode.A))
		{
			//myV3Movement.x *= -Input.GetAxis("Horizontal") * mySpeed;
			myV3Movement.x += -mySpeed;
		}      

		if(Input.GetKeyDown(KeyCode.D))
		{
			//myV3Movement.x *= Input.GetAxis("Horizontal") * mySpeed;
			myV3Movement.x += mySpeed;
		}

		if(!myController.isGrounded)
		{
			myV3Movement.y += myGravity;
		}
		else
		{
			myV3Movement.y = 0;
		}

		myV3Movement = transform.TransformDirection(myV3Movement);
		myController.Move(myV3Movement * Time.deltaTime);
	}
}


