﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 myValue;

    public void SetValueFromTransform(Vector3 objTransform)
    {
        myValue = objTransform;
    }

    public void SetValueFromRotation(Transform objRotation)
    {
        myValue = objRotation.eulerAngles;
    }

    public void SetValueFromMousePosition(Camera cam)
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hit, 100))
        {
            myValue = hit.point;
        }
    }
}
