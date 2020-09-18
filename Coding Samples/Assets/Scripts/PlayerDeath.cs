using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public IntData objHealth, playerLives, respawnHealth;
    public GameObject objForDeath;
    public float waitTime;

    private void Update()
    {
        if (objHealth.myValue <= 0)
        {
            objForDeath.gameObject.SetActive(false);
            if (objForDeath.name == "Player")
            {
                CharacterDeath();
            }
        }
    }

    private IEnumerator CharacterDeath()
    {
        yield return new WaitForSeconds(waitTime);
    }
}
