using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ManaController : ProcessingController
{
    [SerializeField]
    float mana;
    float manaRecoveryStart;
    [SerializeField]
    float manaRecoveryTime;

    float startManaTime = 3f;
    float manaTimer;
    bool isUseSpell;


    private void Awake()
    {
        currentValue = maxValue;
        SetMaxValue(currentValue);
        SetValue(currentValue);
    }

    private void Update()
    {
        if (isUseSpell)
        {
            manaTimer -= Time.deltaTime;
            if (manaTimer < 0)
                isUseSpell = false;
        }
        if (!isUseSpell)
        {
            if (currentValue < maxValue)
            {
                manaRecoveryStart -= Time.deltaTime;
                if (manaRecoveryStart <= 0)
                {
                    ManaRecovery(mana);
                    manaRecoveryStart = manaRecoveryTime;
                }
            }
        }
    }
    public void UseSpell(float mana)
    {
        if (currentValue - mana <= 0)
        {
            SetValue(0);
        }
        else
        {
            SetValue(currentValue - mana);
            isUseSpell = true;
            manaTimer = startManaTime;
        }
        
    }
    public void ManaRecovery(float mana)
    {
        if (currentValue >= maxValue)
        {
            Debug.Log("You Are Max Health");
            return;
        }
        else if (currentValue < maxValue)
        {
            if (currentValue + mana >= maxValue)
            {
                SetValue(maxValue);
                Debug.Log("Your just recovery: " + mana + " Current Mana: " + currentValue);
                return;
            }
            else
            {
                SetValue(currentValue + mana);
                Debug.Log("Your just recovery: " + mana + " Current Mana: " + currentValue);
                return;
            }
        }
    }

    public void SetNewMana(float newMana)
    {
        maxValue = newMana;
        currentValue = maxValue;
        SetMaxValue(maxValue);
        SetValue(currentValue);
    }

    public float GetCurrentHP()
    {
        return currentValue;
    }
}
