using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class WaterBoltProjectile : ProjectileController
{ 
    protected override void Update()
    {
        base.Update();
    }

    protected override void ProjectileMove()
    {
        Move(transform.right);
    }

    protected override void ProjectTileDamage(string name)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.04f);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].tag == name)
            {
                IHit onHit = hits[i].transform.gameObject.GetComponent<IHit>();
                if (onHit != null)
                {
                    onHit.TakeDamage(damage);
                    Create.Instance.CreateHitExplosion(transform.position);
                    PoolingObject.DestroyPooling<WaterBoltProjectile>(this);
                    return;
                }
            }
            else if (hits[i].tag == "Walls" || hits[i].tag == "Blocking")
            {
                Create.Instance.CreateHitExplosion(transform.position);
                PoolingObject.DestroyPooling<WaterBoltProjectile>(this);
            }
        }
    }

}
