﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float value;
    public UnityEvent setValueEvent, incrementValueEvent, lessThanZeroEvent, greaterThanOneEvent;

    public void SetValue(float number)
    {
        value = number;
        setValueEvent.Invoke();
    }

    public void IncrementFromCustomValue(float incrementValue)
    {
        value += incrementValue;
        
        if (value <= 0.0001f && value >= -0.0001f)
        {
            value = 0;
        }
        
        incrementValueEvent.Invoke();
    }

    public void IncrementFromScriptableObject(FloatData data)
    {
        value += data.value;
        
        if (value <= 0.0001f && value >= -0.0001f)
        {
            value = 0;
        }
        
        
        incrementValueEvent.Invoke();
    }

    public void CompareValue()
    {
        if (value <= 0)
        {
            lessThanZeroEvent.Invoke();
        }
        
        if (value >= 1)
        {
            greaterThanOneEvent.Invoke();
        }
    }

    public void SetImageFillAmount(Image image)
    {
        // if (value >= 0 || value <= 1)
        // {
        //     
        // }
        image.fillAmount = value;
        // if (value <= 0)
        // {
        //     lessThanZeroEvent.Invoke();
        // }
        //
        // if (value >= 1)
        // {
        //     greaterThanOneEvent.Invoke();
        // }
    }
}
