using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMonsterController : EnemyController
{
    protected override void EnemyAI()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) > 0.15f)
        {
            animator.Play("Attack");
            ProjectTileMove((Player.Instance.transform.position - transform.position).normalized);
            transform.up = transform.position - Player.Instance.transform.position;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        EnemyDamage();
    }

    protected override void Die()
    {
        Player.Instance.expController.GetEXP(exp);
        GameManager.instance.Gold += gold;
        GameManager.instance.goldText.text = GameManager.instance.Gold.ToString();
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
