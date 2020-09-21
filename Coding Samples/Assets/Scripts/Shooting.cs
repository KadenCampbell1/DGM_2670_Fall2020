using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Instancer instanceObj;
    public ApplyForce forceObj;

    private void Start()
    {
        instanceObj = GetComponent<Instancer>();
        //forceObj = GetComponent<ApplyForce>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var forward = gameObject.transform.forward;
            instanceObj.rotationDirection = forward;
            //instanceObj.rotationDirection.y = 0;
            forceObj.forceDirection = forward;
            //forceObj.forceDirection.y = 0;
            instanceObj.Instance();
        }
    }
}
