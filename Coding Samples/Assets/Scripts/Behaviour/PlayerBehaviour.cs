using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerBehaviour : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement, lookDirection;
    private float yVar;
    private bool canMove = true, canJump = true, canSprint = true;
    private float gravity = -9.81f;
    public FloatData normalSpeed, fastSpeed, jumpForce;
    private FloatData currentSpeed;
    public IntData playerJumpMax;
    private int jumpCount;
    public float pushForce;
    

    public float waitTime;
    private WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    private WaitForSeconds wfs;

    private void Start()
    {
        currentSpeed = normalSpeed;
        controller = GetComponent<CharacterController>();
        StartCoroutine(Move());
        wfs = new WaitForSeconds(waitTime);
    }

    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            canJump = false;
            StartCoroutine(Jump());
        }

        if (Input.GetButton("Fire3"))
        {
            canSprint = false;
            StartCoroutine(Sprint());
        }
    }


    private IEnumerator Move()
    {
        canMove = true;
        while (canMove)
        {
            yield return wffu;
            
            yVar += gravity * Time.deltaTime;

            var vInput = Input.GetAxis("Vertical") * currentSpeed.myValue * Time.deltaTime;
            var hInput = Input.GetAxis("Horizontal") * currentSpeed.myValue * Time.deltaTime;

            lookDirection.Set(hInput, 0, vInput);
            if (lookDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
            
            movement.Set(hInput, yVar, vInput);
            controller.Move(movement);

        }
    }

    private IEnumerator Jump()
    {
        canJump = true;
        while (canJump)
        {
            if (controller.isGrounded && movement.y < 0)
            {
                yVar = -1;
                jumpCount = 0;
            }

            if (Input.GetButtonDown("Jump") && jumpCount < playerJumpMax.myValue)
            {
                yVar = jumpForce.myValue;
                jumpCount++;
            }
            yield return wffu;
        }
    }

    private IEnumerator Sprint()
    {
        canSprint = true;
        while (canSprint)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                currentSpeed = fastSpeed;
            }
            else if (Input.GetButtonUp("Fire3"))
            {
                currentSpeed = normalSpeed;
            }
            yield return wffu;
        }
    }

    private IEnumerator KnockBack(ControllerColliderHit hit, Rigidbody rBody)
    {
        canMove = false;
        var pushDistance = 2f;
        movement = -hit.moveDirection;
        movement.y = -1;
        while (pushDistance > 0)
        {
            yield return wffu;
            pushDistance -= 0.1f;
            controller.Move(movement * Time.deltaTime);
            
            var pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            var forces = pushDirection * pushForce;
            rBody.AddForce(forces);
        }
        movement = Vector3.zero;
        StartCoroutine(Move());
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var rbody = hit.collider.attachedRigidbody;
        if (rbody == null || rbody.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        StartCoroutine(KnockBack(hit, rbody));
    }
}
