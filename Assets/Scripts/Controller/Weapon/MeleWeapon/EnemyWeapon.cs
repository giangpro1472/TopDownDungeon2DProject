using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : Collideable
{
    public float knockTime;
    public float damage;
    public float knockbackForce;

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            IHit onHit = coll.transform.gameObject.GetComponent<IHit>();
            if (onHit != null)
            {
                onHit.TakeDamage(damage);
            }
        }
    }

    protected void Knockback(Collider2D coll)
    {
        if (coll == null)
        {
            return;
        }
        else
        {
            Rigidbody2D rb = coll.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log(rb.name);
                Vector2 difference = rb.transform.position - transform.position;
                difference = difference.normalized * knockbackForce;
                rb.AddForce(difference, ForceMode2D.Impulse);
                Debug.Log("Knockback");
                StartCoroutine(KnockCo(rb));
            }
        }

    }

    protected IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy == null)
        {
            yield break;

        }
        else
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector3.zero;
        }
    }
}
