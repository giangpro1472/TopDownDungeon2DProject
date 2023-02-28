using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    public static VolumeSetting instance;
    public GameObject settingUI;
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SettingOn()
    {
        settingUI.SetActive(true);
    }

    public void SettingOff()
    {
        settingUI.SetActive(false);
    }

}
