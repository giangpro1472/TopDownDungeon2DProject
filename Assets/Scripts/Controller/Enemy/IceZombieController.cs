using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceZombieController : EnemyController
{
    public FreezeController IceEffect;
    public float timeAttack = 3.0f;
    public bool isAttack;
    float attackCoolDown;

    public static List<IceZombieController> iceZombieControllers = new List<IceZombieController>();

    protected override void Start()
    {
        base.Start();
        iceZombieControllers.Add(this);
    }

    private void OnDestroy()
    {
        iceZombieControllers.Remove(this);
    }
    protected override void EnemyAI()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) > 0.2f)
        {
            ProjectTileMove((Player.Instance.transform.position - transform.position).normalized);
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
                        FreezeController ice = Instantiate(IceEffect, hits[i].transform);
                        ice.transform.localPosition = Vector3.zero;
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
        AudioController.instance.PlaySFX("IceZombie");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, triggerLenght);
    }
}
