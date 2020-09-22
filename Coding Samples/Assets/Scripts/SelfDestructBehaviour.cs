using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructBehaviour : MonoBehaviour
{
    public float waitTime = 5f;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
