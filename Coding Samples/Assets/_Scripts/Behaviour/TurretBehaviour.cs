using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public void OnLook(Vector3Data obj)
    {
        transform.LookAt(obj.myValue);
        var rotationDirection = transform.eulerAngles;
        rotationDirection.x = 0;
        rotationDirection.y -= 90f;
        transform.rotation = Quaternion.Euler(rotationDirection);
    }
}
