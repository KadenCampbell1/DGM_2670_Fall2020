using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocatorBehaviour : MonoBehaviour
{
    private Camera myCamera;

    public Transform pointObj;

    private void Start()
    {
        myCamera = Camera.main;
    }

    private void Update()
    {
        if (Physics.Raycast(myCamera.ScreenPointToRay(Input.mousePosition), out var hit, 100))
        {
            pointObj.position = hit.point;
        }
    }
}
