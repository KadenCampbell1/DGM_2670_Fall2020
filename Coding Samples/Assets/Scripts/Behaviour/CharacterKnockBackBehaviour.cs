using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterKnockBackBehaviour : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 move = Vector3.left;
    public float pushPower = 10f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        controller.Move(move * Time.deltaTime);
    }

    private IEnumerator KnockBack(ControllerColliderHit hit)
    {
        var i = 2f;
        move = hit.collider.attachedRigidbody.velocity * i;
        while (i > 0)
        {
            yield return new WaitForFixedUpdate();
            i -= 0.1f;
        }
        move = Vector3.left;
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
        rBody.velocity = pushDirection * pushPower;
    }
}
