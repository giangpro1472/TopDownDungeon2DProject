using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class SkeletonController : EnemyController
{
    public static List<SkeletonController> skeletons = new List<SkeletonController>();

    protected override void Start()
    {
        base.Start();
        skeletons.Add(this);
        Debug.Log("Add Skeleton");
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

    private void OnDestroy()
    {
        skeletons.Remove(this);
        Debug.Log("Destroy Skeleton");
    }

    protected override void Die()
    {
        base.Die();
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
