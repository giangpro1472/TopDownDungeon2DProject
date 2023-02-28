using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EXPController : ProcessingController
{
    public int level;

    [SerializeField]
    float maxLevel = 5;

    public delegate void LevelUp(int level);

    public LevelUp levelUp;

    public TextMeshProUGUI txt;

    [SerializeField]
    TextMeshProUGUI expText;

    private void Awake()
    {
        level = 1;
        currentValue = 0;
        SetMaxValue(maxValue);
        SetValue(currentValue);
        
        txt.text = level.ToString();
        expText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }

    public void SetLevel(int level)
    {
        this.level = level;
        txt.text = level.ToString();
        if (levelUp != null)
        {
            levelUp(level);
        }
    }

    public void SetExp(float exp)
    {
        SetValue(exp);
        if (level == maxLevel)
        {
            expText.text = "Max";
        }
        else
        {
            expText.text = currentValue.ToString() + " / " + maxValue.ToString();
        }
        
    }

    public void GetEXP(float exp)
    {
        if (level < maxLevel)
        {
            SetValue(currentValue + exp);
            expText.text = currentValue.ToString() + " / " + maxValue.ToString();
            if (currentValue >= maxValue)
            {
                level++;
                txt.text = level.ToString();
                AudioController.instance.PlaySFX("LevelUp");
                TextManager.Instance.Show("LEVEL UP!", 25, Color.green, Player.Instance.transform.position, Vector3.up * 25, 1.5f);
                SetLevel(level);
                return;
            }
        }
    }

    public void SetMaxEXP(float newMaxExp)
    {
        maxValue = newMaxExp;
        SetMaxValue(maxValue);
        if (level == maxLevel)
        {
            currentValue = maxValue;
            SetValue(currentValue);
            expText.text = "Max";
            return;
        }
        expText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }
}
