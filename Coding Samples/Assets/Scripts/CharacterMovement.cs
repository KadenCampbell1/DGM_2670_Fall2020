using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
	private CharacterController myController;
	private Vector3 v3Movement;
	private float yAxisVar;

	public float dodgeForce = 15f, myRotateSpeed = 150f, myRotateBoost = 100f, myJumpForce = 5f, myGravity = -9.81f;
	public bool drivingCar, canDodge;

	public FloatData normalSpeed, fastSpeed, myCarSpeed;
	private FloatData currentSpeed;

	public IntData playerJumpMax;
	private int jumpCount;

	public Vector3Data currentSpawnPoint;
	
	void Start()
	{
	    myController = GetComponent<CharacterController>();
	    currentSpeed = normalSpeed;
	}


	void Update()
	{
		yAxisVar += myGravity * Time.deltaTime;

		if (myController.isGrounded && v3Movement.y < 0)
		{
			yAxisVar = -1f;
			jumpCount = 0;
		}

		if (!drivingCar)
		{
			if (Input.GetButtonDown("Fire3"))
			{
				currentSpeed = fastSpeed;
			}
			else if (Input.GetButtonUp("Fire3"))
			{
				currentSpeed = normalSpeed;
			}
			
			if (Input.GetButtonDown("Jump") && jumpCount < playerJumpMax.myValue)
			{
				yAxisVar = myJumpForce;
				jumpCount++;
			}

			if (Input.GetButtonDown("Fire1")) 
			{ 
				Debug.Log("Dodge"); 
				//mySpeed = dodgeForce; 
				canDodge = false;
			}
			
			if (Input.GetButtonUp("Fire1")) 
			{ 
				currentSpeed = normalSpeed; 
				canDodge = true;
			}
			
			
			var verticalInput = Input.GetAxis("Vertical") * currentSpeed.myValue;
			var horizontalInput = Input.GetAxis("Horizontal") * currentSpeed.myValue;
			
			
			var lookDirection = new Vector3(horizontalInput / currentSpeed.myValue, 0f, verticalInput / currentSpeed.myValue);
			
			v3Movement.Set(horizontalInput, yAxisVar, verticalInput);
			transform.rotation = Quaternion.LookRotation(lookDirection);
		}
		if (drivingCar)
		{
			var verticalInput = Input.GetAxis("Vertical") * myCarSpeed.myValue;
			v3Movement.Set(verticalInput, yAxisVar, 0);
			
			if (Input.GetButtonDown("Fire3"))
			{
				myRotateSpeed += myRotateBoost;
			}
			else if (Input.GetButtonUp("Fire3"))
			{
				myRotateSpeed -= myRotateBoost;
			}
			
			var horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * myRotateSpeed;
			transform.Rotate(0, horizontalInput, 0);
			
			v3Movement = transform.TransformDirection(v3Movement);
		}
		
		
		myController.Move(v3Movement * Time.deltaTime);
	}

	private void OnEnable()
	{
		gameObject.transform.position = currentSpawnPoint.myValue;
	}
}


