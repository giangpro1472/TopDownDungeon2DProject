using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRing : Collideable
{
    public float damage;
    public BurnEffect burnEffect;
    PolygonCollider2D polygon;

    protected override void Start()
    {
        base.Start();
        polygon = GetComponent<PolygonCollider2D>();
    }

    protected override void Update()
    {
        polygon.OverlapCollider(fillter, hits);
        //boxCollider.OverlapCollider(fillter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }
            OnCollide(hits[i]);
            hits[i] = null;
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            IHit onHit = coll.transform.gameObject.GetComponent<IHit>();
            if (onHit != null)
            {
                if (coll.tag == "Player" && !coll.GetComponent<PlayerController>().isInvincible)
                {
                    BurnEffect fire = Instantiate(burnEffect, coll.transform);
                    fire.transform.localPosition = Vector3.zero;
                    onHit.TakeDamage(damage);
                }
            }
        }
    }
}
