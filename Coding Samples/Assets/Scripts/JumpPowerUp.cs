using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public IntData playerJumpCount, normalJumpCount, powerUpCount;
    public float waitTime = 2f;

    private void Start()
    {
        playerJumpCount.myValue = normalJumpCount.myValue;
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        playerJumpCount.myValue = powerUpCount.myValue;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        playerJumpCount.myValue = normalJumpCount.myValue;
        gameObject.SetActive(false);
    }
}
