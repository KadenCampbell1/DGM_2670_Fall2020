using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public IntData health, respawnHealth, lifeTotal;
    private int gameOver = 0;
    public Vector3Data currentSpawn;
    public int waitTime;
    private MeshRenderer meshRenderer;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // private IEnumerator DeathEvent()
    //     {
    //         meshRenderer.enabled = false;
    //         characterController.enabled = false;
    //         yield return new WaitForSeconds(waitTime);
    //         health.myValue = respawnHealth.myValue;
    //         gameObject.transform.position = currentSpawn.myValue;
    //         meshRenderer.enabled = true;
    //         characterController.enabled = true;
    //     }

    private void DeathEvent()
    {
        if (lifeTotal.myValue > gameOver)
        {
            gameObject.transform.position = currentSpawn.myValue;
            health.myValue = respawnHealth.myValue;
            lifeTotal.myValue--;
        }
        else
        {
            gameObject.transform.position = currentSpawn.myValue;
        }
        
    }

    private void Update()
    {
        if (health.myValue <= 0)
        {
            DeathEvent();
        }
    }

    
}
