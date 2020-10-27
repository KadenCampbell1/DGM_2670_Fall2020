using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventsBehaviour : MonoBehaviour
{
    public UnityEvent onTriggerEnterEvent, onTriggerExitEvent;

    public void OnTriggerEnter(Collider other)
    {
        onTriggerEnterEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExitEvent.Invoke();
    }
}
