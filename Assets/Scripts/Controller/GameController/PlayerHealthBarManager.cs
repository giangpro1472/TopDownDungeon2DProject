using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBarManager : MonoBehaviour
{
    public static PlayerHealthBarManager instance;
    void Start()
    {
        if (PlayerHealthBarManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
