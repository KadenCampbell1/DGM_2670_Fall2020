using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehaviour : MonoBehaviour
{
    public UnityEvent startEvent, onEnableEvent, triggerEvent, playerTriggerCollision, enemyTriggerCollision, bulletTriggerCollision;
    private WaitForSeconds waitObj;
    public float waitTime;

    private void Start()
    {
        startEvent.Invoke();
        waitObj = new WaitForSeconds(waitTime);
    }

    private void OnEnable()
    {
        onEnableEvent.Invoke();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        yield return waitObj;
        triggerEvent.Invoke();
        
        if (other.name == "Character")
        {
            playerTriggerCollision.Invoke();
        }

        if (other.name == "Enemy")
        {
            enemyTriggerCollision.Invoke();
        }

        if (other.name == "Bullet")
        {
            bulletTriggerCollision.Invoke();
        }
    }
}
