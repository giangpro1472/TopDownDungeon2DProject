using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class DarkCytheProjectile : ProjectileController
{
    protected override void Update()
    {   
        base.Update();
    }

    protected override void ProjectileMove()
    {
        ProjectTileMove(Vector3.zero);
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
                    destroy -= Time.deltaTime;
                    if (destroy <= 0)
                    {
                        Debug.Log("Destroy");
                        PoolingObject.DestroyPooling<DarkCytheProjectile>(this);
                        return;
                    }
                    return;
                }
            }
        }
        destroy -= Time.deltaTime;
        if (destroy <= 0)
        {
            Debug.Log("Destroy");
            PoolingObject.DestroyPooling<DarkCytheProjectile>(this);
            return;
        }
    }
}
