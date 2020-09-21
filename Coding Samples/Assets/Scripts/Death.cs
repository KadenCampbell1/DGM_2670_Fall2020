using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Death : MonoBehaviour
{
    public IntData objHealth, playerLives, respawnHealth;
    public Vector3Data spawnLocation;
    public GameObject objForDeath;
    private CharacterController characterController;

    private void Start()
    {
        if (objForDeath.GetComponent<CharacterController>() == true)
        {
            characterController = GetComponent<CharacterController>();
        }
    }

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
                objForDeath.gameObject.SetActive(true);
            }
            if (playerLives.myValue < 0)
            {
                Debug.Log("GameOver");
            }
        }
    }

    private IEnumerator Wait(float time)
    {
        characterController.enabled = false;
        yield return new WaitForSeconds(time);
        characterController.enabled = true;
    }
    
}
