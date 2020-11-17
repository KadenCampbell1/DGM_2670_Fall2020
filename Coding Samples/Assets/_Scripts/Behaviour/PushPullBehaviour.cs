using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushPullBehaviour : MonoBehaviour
{
    private Rigidbody rBody;
    public bool canPickUp;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        canPickUp = Input.GetKey(KeyCode.LeftControl);
    }

    private void OnTriggerStay(Collider other)
    {
        if (canPickUp)
        {
            transform.parent = other.transform;
            rBody.Sleep();
        }
        else
        {
            transform.parent = null;
            rBody.WakeUp();
        }
    }
}
