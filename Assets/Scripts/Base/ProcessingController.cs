using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessingController : MonoBehaviour
{
    public float currentValue; 
    public float maxValue;

    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxValue(float newValue)
    {
        slider.maxValue = newValue;
        //slider.value = newValue;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetValue(float newValue)
    {
        currentValue = newValue;
        slider.value = newValue;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
