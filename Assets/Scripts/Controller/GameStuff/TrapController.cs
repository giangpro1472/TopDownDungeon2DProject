using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : Collideable
{
    public float damage;
    bool isTrigger = false;
    
    protected override void Update()
    {
        if (isTrigger)
        {
            base.Update();
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
          IHit onHit = coll.transform.gameObject.GetComponent<IHit>();
          if (onHit != null)
          {
             onHit.TakeDamage(damage);
             return;
          }
        }
    }

    public void Attack()
    {
        isTrigger = true;
    }

    public void Idle()
    {
        isTrigger = false;
    }

}
