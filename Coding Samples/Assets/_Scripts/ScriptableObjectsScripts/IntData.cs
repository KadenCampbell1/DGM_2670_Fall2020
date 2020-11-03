using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int myValue;

    public void IncrementFromCustomValue(int incrementValue)
    {
        myValue += incrementValue;
    }

    public void IncrementFromScriptableObject(IntData data)
    {
        myValue += data.myValue;
    }
}
