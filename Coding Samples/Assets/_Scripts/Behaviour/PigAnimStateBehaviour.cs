using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PigAnimStateBehaviour : MonoBehaviour
{

    public UnityEvent forwardEvent, backwardEvent, idleEvent;

    private void Start()
    {
        idleEvent.Invoke();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            forwardEvent.Invoke();
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            backwardEvent.Invoke();
        }

        if (!Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") == 0)
        {
            idleEvent.Invoke();
        }
    }
}
