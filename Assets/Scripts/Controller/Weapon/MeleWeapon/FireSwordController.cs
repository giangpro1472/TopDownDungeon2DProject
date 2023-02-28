using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSwordController : SwordController
{
    public BurnEffect burnEffect;
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
                    BurnEffect fire = Instantiate(burnEffect, coll.transform);
                    fire.transform.localPosition = Vector3.zero;
                }
                else
                { 
                    onHit.TakeDamage(damage);
                }
            }
        }
    }

    protected override void Attack()
    {
        anim.SetTrigger("Attack");
        AudioController.instance.PlaySFX("FireSword");
    }
}
