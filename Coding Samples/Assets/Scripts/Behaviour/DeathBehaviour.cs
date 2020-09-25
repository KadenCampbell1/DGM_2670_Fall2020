﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DeathBehaviour : MonoBehaviour
{
    public IntData objHealth, playerLives, respawnHealth;
    public Vector3Data spawnLocation;
    public GameObject objForDeath;
    public float waitTime = 3f;
    

    private void Update()
    {
        if (objHealth.myValue <= 0)
        {
            objForDeath.gameObject.SetActive(false);
            if (objForDeath.name == "Character")
            {
                playerLives.myValue--;
            }
            if (objForDeath.name == "Character" && playerLives.myValue > 0)
            {
                objForDeath.gameObject.transform.position = spawnLocation.myValue;
                objHealth.myValue = respawnHealth.myValue;
                StartCoroutine(Wait(waitTime));
            }
            if (playerLives.myValue < 0)
            {
                Debug.Log("GameOver");
            }
        }
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        objForDeath.gameObject.SetActive(true);
    }
    
}