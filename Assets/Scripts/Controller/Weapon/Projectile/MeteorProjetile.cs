using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
public class MeteorProjetile : ProjectileController
{
    Vector3 PlayerCurrentPosition;
    protected override void Update()
    {
        base.Update();
        destroy = destroyTime;
        destroy -= Time.deltaTime;
        if (destroy <= 0)
        {
            Create.Instance.CreateHitExplosion(transform.position);
            PoolingObject.DestroyPooling<MeteorProjetile>(this);
            return;
        }
    }

    protected override void Start()
    {
        base.Start();
        PlayerCurrentPosition = Player.Instance.transform.position;
    }

    protected override void ProjectileMove()
    {
        ProjectTileMove(PlayerCurrentPosition - transform.position);
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
                    PoolingObject.DestroyPooling<MeteorProjetile>(this);
                    return;
                }
            }
            else
            {
                Create.Instance.CreateDestroyExplosion(transform.position);
                PoolingObject.DestroyPooling<ProjectileController>(this);
                return;
            }
        }
    }
}
