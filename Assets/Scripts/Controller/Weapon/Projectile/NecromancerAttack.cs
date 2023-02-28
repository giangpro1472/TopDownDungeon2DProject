using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class NecromancerAttack : ProjectileController
{
    protected override void ProjectTileDamage(string name)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.07f);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].tag == name)
            {
                IHit onHit = hits[i].transform.gameObject.GetComponent<IHit>();
                if (onHit != null)
                {
                    onHit.TakeDamage(damage);
                    Create.Instance.CreateHitExplosion(transform.position);
                    PoolingObject.DestroyPooling<NecromancerAttack>(this);
                    return;
                }
            }
            else if(hits[i].tag == "Weapons" || hits[i].tag == "Blocking" || hits[i].tag == "Walls")
            {
                Create.Instance.CreateDestroyExplosion(transform.position);
                PoolingObject.DestroyPooling<NecromancerAttack>(this);
                return;
            }
        }
        destroy -= Time.deltaTime;
        if (destroy <= 0)
        {
            Create.Instance.CreateDestroyExplosion(transform.position);
            Destroy(this.gameObject);
            return;
        }
    }
}
