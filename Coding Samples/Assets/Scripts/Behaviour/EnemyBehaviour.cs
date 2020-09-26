using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public IntData enemyHealthData;
    public int enemyHealth;

    public void Start()
    {
        enemyHealth = enemyHealthData.myValue;
    }

    public void IncrementEnemyHealthFromSO(IntData myInt)
    {
        enemyHealth += myInt.myValue;
    }
}
