using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancerBehaviour : MonoBehaviour
{
    public GameObject prefab;
    public Vector3Data rotationDirection;

    public void InstanceWithRotationDirection()
    {
        var location = transform.position;
        var newObj = Instantiate(prefab, location, Quaternion.Euler(rotationDirection.myValue));
    }

    public void InstanceObj()
    {
        var location = transform.position;
        var rotation = transform.rotation;
        var newObj = Instantiate(prefab, location, rotation);
    }
    
    public void InstanceObj(GameObject obj)
    {
        var location = transform.position;
        var rotation = transform.rotation;
        var newObj = Instantiate(obj, location, rotation);
    }
}
