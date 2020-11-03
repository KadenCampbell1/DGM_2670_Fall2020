using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 myValue;

    public void SetValueFromVector3(Vector3 objTransform)
    {
        myValue = objTransform;
    }

    public void SetValueFromPosition(Transform objPosition)
    {
        myValue = objPosition.position;
    }
    
    public void SetPositionFromValue(Transform objPosition)
    {
        objPosition.position = myValue;
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
