using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
	private CharacterController myController;
	private Vector3 v3Movement, knockBackMovement = Vector3.zero, lookDirection;
	private float yAxisVar;

	public float dodgeForce = 15f, 
		myRotateSpeed = 150f, myRotateBoost = 100f,
		myGravity = -9.81f,
		pushForce = 10f;
	public bool drivingCar, canDodge;

	public FloatData normalSpeed, fastSpeed, myCarSpeed, myJumpForce;
	private FloatData currentSpeed;

	public IntData playerJumpMax;
	private int jumpCount;

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
				yAxisVar = myJumpForce.myValue;
				jumpCount++;
			}

			if (Input.GetButtonDown("Fire2")) 
			{ 
				Debug.Log("Dodge"); 
				//mySpeed = dodgeForce; 
				canDodge = false;
			}
			
			if (Input.GetButtonUp("Fire2")) 
			{ 
				currentSpeed = normalSpeed; 
				canDodge = true;
			}
			
			
			var verticalInput = Input.GetAxis("Vertical") * currentSpeed.myValue;
			var horizontalInput = Input.GetAxis("Horizontal") * currentSpeed.myValue;
			
			lookDirection.Set(horizontalInput, 0, verticalInput);

			if (lookDirection == Vector3.zero)
			{
				lookDirection.Set(0.0001f, 0, 0.0001f);
			}
        
			if (horizontalInput > 0.5f || horizontalInput < -0.5f ||verticalInput > 0.5f || verticalInput < -0.5f)
			{
				transform.rotation = Quaternion.LookRotation(lookDirection);
			}
			
			v3Movement.Set(horizontalInput, yAxisVar, verticalInput);
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
		
		
		myController.Move((v3Movement + knockBackMovement) * Time.deltaTime);
	}

	private IEnumerator KnockBack(ControllerColliderHit hit)
	{
		var i = 2f;
		knockBackMovement = hit.collider.attachedRigidbody.velocity * (i * pushForce);
		while (i > 0)
		{
			yield return new WaitForFixedUpdate();
			i -= 0.1f;
		}
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		var rBody = hit.collider.attachedRigidbody;
		if (rBody == null || rBody.isKinematic)
		{
			return;
		}
		
		StartCoroutine(KnockBack(hit));
		var pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		rBody.velocity = pushDirection * pushForce;
	}
}


