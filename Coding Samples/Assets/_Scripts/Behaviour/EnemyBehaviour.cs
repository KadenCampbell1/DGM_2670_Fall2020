﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public FloatData enemyHealthData, damageData;
    public float enemyHealth;

    public void Start()
    {
        enemyHealth = enemyHealthData.value;
    }

    public void IncrementEnemyHealthFromSO(FloatData myFlt)
    {
        enemyHealth += myFlt.value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bullet(Clone)")
        {
            IncrementEnemyHealthFromSO(damageData);
        }
    }
}
