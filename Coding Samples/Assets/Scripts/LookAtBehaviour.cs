using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBehaviour : MonoBehaviour
{
    public Transform lookedAtObj;

    public void Update()
    {
        transform.LookAt(lookedAtObj);
        var rotationDirection = transform.eulerAngles;
        rotationDirection.x = 0;
        transform.rotation = Quaternion.Euler(rotationDirection);
    }
}
