using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMinionController : EnemyController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        EnemyDamage();
    }

    protected override void EnemyAI()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) > 0.2f)
        {
            ProjectTileMove((Player.Instance.transform.position - transform.position).normalized);
            animator.Play("Run");
        }
        else
        {
            Debug.Log("Attack");
            animator.Play("Idle");
        }
    }

    protected override void Die()
    {
        isDead = true;
        Player.Instance.expController.GetEXP(exp);
        GameManager.instance.Gold += gold;
        GameManager.instance.goldText.text = GameManager.instance.Gold.ToString();
        Destroy(gameObject);
        AudioController.instance.PlaySFX("Skeleton");
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

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
