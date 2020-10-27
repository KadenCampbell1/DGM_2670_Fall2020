using System;
using System.Collections;
using UnityEngine;


public class CharacterBehaviour : CharacterBehaviourBase
{
	void Update()
	{
		MoveCharacter();
		if (drivingCar)
		{
			var verticalInput = Input.GetAxis("Vertical") * myCarSpeed.value;
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
		
		//myController.Move((v3Movement + knockBackMovement) * Time.deltaTime);
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


