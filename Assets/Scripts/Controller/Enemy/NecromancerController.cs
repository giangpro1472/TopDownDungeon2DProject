using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerInfo
{
    public float HP;
    public float speed;
    public float damage;
}
public class NecromancerController : EnemyController
{
    public static List<NecromancerController> necromancers = new List<NecromancerController>();

    protected override void Start()
    {
        base.Start();
        necromancers.Add(this);
    }

    private void OnDestroy()
    {
        necromancers.Remove(this);
    }

    public float attackTime;
    float startAttackTime;

    protected override void Awake()
    {
        startAttackTime = attackTime;
        base.Awake();
    }
    protected override void EnemyAI()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) > attackRange)
        {

            ProjectTileMove((Player.Instance.transform.position - transform.position).normalized);
        }
        else
        {
            
            if (hpController.GetCurrentHP() <= hpController.maxValue / 2)
            {

                ProjectTileMove(Vector3.zero);
                SummonDemon();
            }
            else
            {
                ProjectTileMove(Vector3.zero);
                Shoot();
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
            Debug.Log("Player take damage");
            AudioController.instance.PlaySFX("Hit");
        }

    }

    protected override void Die()
    {
        base.Die();
        AudioController.instance.PlaySFX("Necromancer");
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void Shoot()
    {
        startAttackTime -= Time.deltaTime;
        if (startAttackTime <= 0)
        {
            NecromancerAttack attack = Create.Instance.CreateNecromancerAttack(attackPoint);
            attack.damage = damage;
            startAttackTime = attackTime;
            return;
        }
    }

    public void SummonDemon()
    {
        startAttackTime -= Time.deltaTime;
        if (startAttackTime <= 0)
        {
            NecromancerSpecialAttack attack = Create.Instance.CreateNecromancerSpecialAttack(attackPoint);
            attack.damage = damage + 2;
            startAttackTime = attackTime;
            return;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
