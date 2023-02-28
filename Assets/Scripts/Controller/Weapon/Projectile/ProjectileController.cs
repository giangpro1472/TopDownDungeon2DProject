using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class ProjectileController : MoveController
{
    public float damage;
    public float destroy;
    public float destroyTime;
    new public string name;

    protected virtual void Awake()
    {
        destroy = destroyTime;
        DontDestroyOnLoad(this);
    }
    protected virtual void Update()
    {   
        ProjectileMove();
        ProjectTileDamage(name);
    }

    protected virtual void ProjectileMove()
    {
        ProjectTileMove(Player.Instance.transform.position - transform.position);
    }

    protected virtual void ProjectTileDamage(string name)
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
                    PoolingObject.DestroyPooling<ProjectileController>(this);
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
        destroy -= Time.deltaTime;
        if (destroy <= 0)
        {
            Create.Instance.CreateDestroyExplosion(transform.position);
            Destroy(this.gameObject);
            return;
        }
    }

}
