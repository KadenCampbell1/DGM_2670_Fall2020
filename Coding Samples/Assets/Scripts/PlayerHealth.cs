using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public IntData health, respawnHealth;
    public Vector3Data currentSpawn;
    public int waitTime;

    private void Update()
    {
        if (health.myValue <= 0)
        {
            //invoke the EVENT
        }
    }

    private IEnumerator DeathEvent()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        health.myValue = respawnHealth.myValue;
        gameObject.transform.position = currentSpawn.myValue;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
    }
}
