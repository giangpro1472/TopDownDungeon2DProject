using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KnightController : PlayerController
{
    public static KnightController instance;
    protected override void Start()
    {
        if (KnightController.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        base.Start();
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    protected override void Die()
    {
        Debug.Log("Player Died");
        GameManager.instance.GameOver();
    }
}
