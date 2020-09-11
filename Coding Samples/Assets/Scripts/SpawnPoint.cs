using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3Data spawnData, currentSpawnPoint;

    private void Start()
    {
        currentSpawnPoint.myValue = spawnData.myValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        spawnData.myValue = GetComponent<Transform>().position;
    }

    public void Spawn()
    {
        currentSpawnPoint.myValue = spawnData.myValue;
    }
}
