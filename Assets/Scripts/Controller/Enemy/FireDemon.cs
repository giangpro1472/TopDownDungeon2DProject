using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireDemon : EnemyController
{
    public BurnEffect burnEffect;
    protected float timeAttack = 2.0f;
    protected bool isAttack;
    protected float attackCoolDown;

    public static List<FireDemon> fireDemons = new List<FireDemon>();
    protected override void Start()
    {
        base.Start();
        fireDemons.Add(this);
    }
    private void OnDestroy()
    {
        fireDemons.Remove(this);
    }
    protected override void EnemyAI()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) > 0.2f)
        {
            animator.Play("Run");
            ProjectTileMove((Player.Instance.transform.position - transform.position).normalized);
        }
        else
        {
            animator.Play("Idle");
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (isAttack)
        {
            attackCoolDown -= Time.deltaTime;
            if (attackCoolDown < 0)
                isAttack = false;
        }
        EnemyDamage();
    }

    protected override void EnemyDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].name == "Player")
            {
                IHit onHit = hits[i].transform.gameObject.GetComponent<IHit>();
                if (onHit != null)
                {
                    if (!isAttack)
                    {
                        isAttack = true;
                        attackCoolDown = timeAttack;
                        onHit.TakeDamage(damage);
                        BurnEffect fire = Instantiate(burnEffect, hits[i].transform);
                        fire.transform.localPosition = Vector3.zero;
                        return;
                    }
                }
            }
        }
    }

    public override void TakeDamage(float damage)
    {
        if (isInvincible)
        {
            return;
        }
        else
        {
            base.TakeDamage(damage);
            AudioController.instance.PlaySFX("Hit");
        }

    }
    protected override void Die()
    {
        base.Die();
        AudioController.instance.PlaySFX("FireDemon");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
