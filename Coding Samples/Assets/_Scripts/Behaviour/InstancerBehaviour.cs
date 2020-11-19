using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstancerBehaviour : MonoBehaviour
{
    public GameObject prefab;
    public Vector3Data rotationDirection;
    public float holdTime = 0.5f;
    public bool canLoop = false;
    public int instanceCount = 30;
    private int counter = 0;
    
    public UnityEvent startEvent, onCallEvent;
    
    private WaitForSeconds wfs;

    private void Start()
    {
        wfs = new WaitForSeconds(holdTime);
        startEvent.Invoke();
    }

    public void StartLoopEvents()
    {
        canLoop = true;
        StartCoroutine(CallInstanceEvent());
    }
    
    private IEnumerator CallInstanceEvent()
    {
        while (canLoop && counter < instanceCount)
        {
            onCallEvent.Invoke();
            counter++;
            yield return wfs;
        }
        canLoop = false;
        counter = 0;
    }

    public void InstanceWithRotationDirection()
    {
        var location = transform.position;
        var newObj = Instantiate(prefab, location, Quaternion.Euler(rotationDirection.myValue));
    }

    public void InstanceObj()
    {
        var location = transform.position;
        var rotation = transform.rotation;
        var newObj = Instantiate(prefab, location, rotation);
    }
    
    public void InstanceObj(GameObject obj)
    {
        var location = transform.position;
        var rotation = transform.rotation;
        var newObj = Instantiate(obj, location, rotation);
    }
}
