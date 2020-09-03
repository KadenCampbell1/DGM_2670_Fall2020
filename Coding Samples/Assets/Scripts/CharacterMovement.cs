﻿using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
	private CharacterController myController;
	private Vector3 v3Movement;
	private int jumpCount;
	private float yAxisVar;

	public float mySpeed = 3f, myRotateSpeed = 30f, myJumpForce = 10f, myGravity = -9.81f;
	public int maxJumpCount = 2;
	
	void Start()
	{
	    myController = GetComponent<CharacterController>();
	}


	void Update()
	{
		var verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * mySpeed;
		v3Movement.Set(verticalInput, yAxisVar, 0);

		var horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * myRotateSpeed;
		transform.Rotate(0, horizontalInput, 0);

		yAxisVar += myGravity * Time.deltaTime;

		if (myController.isGrounded && v3Movement.y < 0)
		{
			yAxisVar = -1f;
			jumpCount = 0;
		}

		if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
		{
			yAxisVar = myJumpForce;
			jumpCount++;
		}

		v3Movement = transform.TransformDirection(v3Movement);
		myController.Move(v3Movement * Time.deltaTime);
	}
}


