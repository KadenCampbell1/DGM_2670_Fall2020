using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviourBase : MonoBehaviour
{
    protected CharacterController myController;
    protected Vector3 v3Movement, knockBackMovement = Vector3.zero, lookDirection;
    protected float yAxisVar;

    public float dodgeForce = 15f, 
        myRotateSpeed = 150f, myRotateBoost = 100f,
        myGravity = -9.81f,
        pushForce = 10f;
    public bool drivingCar, canDodge;

    public FloatData normalSpeed, fastSpeed, myCarSpeed, myJumpForce;
    protected FloatData currentSpeed;

    public IntData playerJumpMax;
    protected int jumpCount;
    
    void Start()
    {
        myController = GetComponent<CharacterController>();
        currentSpeed = normalSpeed;
    }
    
    public void MoveCharacter()
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
    				yAxisVar = myJumpForce.value;
    				jumpCount++;
    			}
                
                var verticalInput = Input.GetAxis("Vertical") * currentSpeed.value;
    			var horizontalInput = Input.GetAxis("Horizontal") * currentSpeed.value;
    			
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

            myController.Move((v3Movement) * Time.deltaTime);
    	}
}
