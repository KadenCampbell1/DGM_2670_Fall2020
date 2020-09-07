using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
	private CharacterController myController;
	private Vector3 v3Movement;
	private int jumpCount;
	private float yAxisVar;

	public float mySpeed = 5f, myRunSpeed = 10f, myCarSpeed = 20f, myRotateSpeed = 150f, myRotateBoost = 100f, myJumpForce = 5f, myGravity = -9.81f;
	public int maxJumpCount = 2;
	public bool drivingCar = false;
	
	void Start()
	{
	    myController = GetComponent<CharacterController>();
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
				mySpeed += myRunSpeed;
			}
			else if (Input.GetButtonUp("Fire3"))
			{
				mySpeed -= myRunSpeed;
			}
			
			if (Input.GetButtonDown("Jump") && jumpCount < maxJumpCount)
			{
				yAxisVar = myJumpForce;
				jumpCount++;
			}
			
			var verticalInput = Input.GetAxis("Vertical") * mySpeed;
			var horizontalInput = Input.GetAxis("Horizontal") * mySpeed;
			v3Movement.Set(horizontalInput, yAxisVar, verticalInput);
		}
		if (drivingCar)
		{
			var verticalInput = Input.GetAxis("Vertical") * myCarSpeed;
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
		}
		
		v3Movement = transform.TransformDirection(v3Movement);
		myController.Move(v3Movement * Time.deltaTime);
	}
}


