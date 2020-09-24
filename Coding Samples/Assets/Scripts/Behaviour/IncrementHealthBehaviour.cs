using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementHealthBehaviour : MonoBehaviour
{
    public IntData health, damage;

    private void OnTriggerEnter(Collider other)
    {
        health.myValue -= damage.myValue;
    }
}
