using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrgeController : EnemyController
{
    [SerializeField]EnemyWeapon enemyWeapon;
    protected float cooldown = 1.5f;
    protected float lastAttack;

    public static List<OrgeController> orges = new List<OrgeController>();

    protected override void Start()
    {
        base.Start();
        orges.Add(this);
    }

    private void OnDestroy()
    {
        orges.Remove(this);
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
            Attack();
        }
    }

    void Attack()
   {

        if (Time.time - lastAttack > cooldown)
        {
            lastAttack = Time.time;
            enemyWeapon.anim.SetTrigger("Attack");
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
            Debug.Log("Player take damage");
            AudioController.instance.PlaySFX("Orge");
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, 0.2f);
    }

}
