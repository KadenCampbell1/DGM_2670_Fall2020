﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehaviour : MonoBehaviour
{
    public UnityEvent startEvent, onEnableEvent, triggerEvent, playerTriggerCollision, enemyTriggerCollision, bulletTriggerCollision;
    public float waitTime = 0.1f;
    public bool repeatOnStart;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTime);
        startEvent.Invoke();
        while (repeatOnStart)
        {
            yield return new WaitForSeconds(waitTime);
            startEvent.Invoke();
        }
    }

    private void OnEnable()
    {
        onEnableEvent.Invoke();
    }

    public void DestroyObj(GameObject obj)
    {
        Destroy(obj);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        yield return new WaitForSeconds(waitTime);
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