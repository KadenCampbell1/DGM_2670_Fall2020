using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointBehaviour : MonoBehaviour
{
    public Vector3Data spawnData;
    

    private void OnTriggerEnter(Collider other)
    {
        spawnData.SetValueFromTransform(transform.position);
    }
}
