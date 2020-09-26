using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionTypeEventsBehaviour : MonoBehaviour
{
    public UnityEvent playerTriggerCollision, enemyTriggerCollision, bulletTriggerCollision;

    public void OnTriggerEnter(Collider other)
    {
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
