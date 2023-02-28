using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class SwordController : WeaponController
{
    public float knockTime;   

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag != "Player")
        {
            IHit onHit = coll.transform.gameObject.GetComponent<IHit>();
            if (onHit != null)
            {
                onHit.TakeDamage(damage);
            }
        }
        if (coll.CompareTag("Enemy"))
        {
            IHit onHit = coll.transform.gameObject.GetComponent<IHit>();
            if (onHit != null)
            {
                onHit.TakeDamage(damage);
                Knockback(coll);
            }
        }
    }

    protected void Knockback(Collider2D coll)
    {
        if (!coll.gameObject.GetComponent<EnemyController>().isDead)
        {
            if (coll != null)
            {
                Rigidbody2D rb = coll.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    Debug.Log(rb.name);
                    Vector2 difference = rb.transform.position - transform.position;
                    difference = difference.normalized * knockbackForce;
                    rb.AddForce(difference, ForceMode2D.Impulse);
                    //Debug.Log("Knockback");
                    StartCoroutine(KnockCo(rb));
                }
                return;
            }
        }
       
    }

    protected IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector3.zero;
        }
    }

    protected override void Attack()
    {
        AudioController.instance.PlaySFX("WoodenSword");
        base.Attack();
    }
}

public class Sword : SingletonMonoBehaviour<SwordController>
{

}
