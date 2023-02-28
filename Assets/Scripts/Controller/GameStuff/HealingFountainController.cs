using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountainController : Collideable
{
    public float healing;
    float healingTime = 1.0f;
    float startHealingTime;

    private void Awake()
    {
        startHealingTime = healingTime;
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            startHealingTime -= Time.deltaTime;
            if (startHealingTime <= 0)
            {
                Player.Instance.hpController.Healing(healing);
                startHealingTime = healingTime;
                return;
            }

        }
    }

}
