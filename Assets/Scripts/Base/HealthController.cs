using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthController : ProcessingController
{
    public delegate void Died();

    public Died die;

    private void Awake()
    {
        currentValue = maxValue; 
        SetMaxValue(currentValue);
        SetValue(currentValue);
    }
    
    [SerializeField]

    public void TakeDame(float damage)
    {
        SetValue(currentValue - damage);
        if (currentValue <= 0)
        {
            if (die != null)
            {
                die();
            }

        }
    }
    public void Healing(float hp)
    {
        if (currentValue >= maxValue)
        {
            Debug.Log("You Are Max Health");
            return;
        }
        else if (currentValue < maxValue)
        {
            if (currentValue + hp >= maxValue)
            {
                SetValue(maxValue);
                Debug.Log("Your just heal: " + hp + " Current Health: " + currentValue);
                return;
            }
            else
            {
                SetValue(currentValue + hp);
                Debug.Log("Your just heal: " + hp + " Current Health: " + currentValue);
                return;
            }
        }
    }
    public void SetNewHP(float newHP)
    {
        maxValue = newHP;
        currentValue = maxValue;
        SetMaxValue(maxValue);
        SetValue(currentValue);
    }
    public float GetCurrentHP()
    {
        return currentValue;
    }


}
