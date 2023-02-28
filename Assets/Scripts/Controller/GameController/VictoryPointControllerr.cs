using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPointControllerr : Collectable
{
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            OnCollect();
        }
    }

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GameManager.instance.Victory();
        }
    }
}
