using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DeathBehaviour : MonoBehaviour
{
    public FloatData objHealth, respawnHealth;
    public IntData playerLives;
    public Vector3Data spawnLocation;
    public GameObject objForDeath;
    public float waitTime = 3f;
    

    private void Update()
    {
        if (objHealth.value <= 0)
        {
            objForDeath.gameObject.SetActive(false);
            if (objForDeath.name == "Character")
            {
                playerLives.myValue--;
            }
            if (objForDeath.name == "Character" && playerLives.myValue > 0)
            {
                objForDeath.gameObject.transform.position = spawnLocation.myValue;
                objHealth.value = respawnHealth.value;
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
