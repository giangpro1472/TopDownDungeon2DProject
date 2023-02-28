using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSuckerController : SwordController
{
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag != "Player")
        {
            IHit onHit = coll.transform.gameObject.GetComponent<IHit>();
            if (onHit != null)
            {
                if (coll.tag == "Enemy" && !coll.GetComponent<EnemyController>().isInvincible)
                {
                    Knockback(coll);
                    onHit.TakeDamage(damage);
                    Player.Instance.hpController.Healing(damage / 3);
                }
                else
                {
                    onHit.TakeDamage(damage);
                }
                return;
            }
        }
    }
}
