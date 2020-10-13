using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float myValue;

    public void IncrementFromCustomValue(float incrementValue)
    {
        myValue += incrementValue;
    }

    public void IncrementFromScriptableObject(FloatData data)
    {
        myValue += data.myValue;
    }
}
