using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{
    public static List<BossController> boss = new List<BossController>();
    protected float cooldown = 15.0f;

    [SerializeField] GameObject FlameRing;
    float FlameRingTimer = 10.0f;
    bool FlameRingAttack;


    [SerializeField] GameObject DemonPortalSummon;
    float demonSpawnTime = 5.0f;
    float DemonAttackTimer = 20f;
    bool DemonSummonAttack = false;

    float AttackTimer = 4.0f;


    protected override void Start()
    {
        base.Start();
        boss.Add(this);
        FlameRing.SetActive(false);
        FlameRingAttack = true;
    }

    private void OnDestroy()
    {
        boss.Remove(this);
    }

    [SerializeField] float distance = 0.5f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        EnemyDamage();
    }

    protected override void Update()
    {
        base.Update();
        if (FlameRingAttack)
        {
            FirstAttack();
        }
        if (DemonSummonAttack)
        {
            SecondAttack();
        }
        
        
    }

    protected override void EnemyAI()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) > distance)
        {
            animator.Play("Run");
            ProjectTileMove((Player.Instance.transform.position - transform.position).normalized);
            Debug.Log("Run");
        }
        else
        {
            animator.Play("Idle");
        }
    }

    void Attack()
    {
        Debug.Log("Attack");
    }

    void FirstAttack()
    {
        AttackTimer -= Time.deltaTime;
        if (AttackTimer <= 0)
        {
            FlameRingTimer -= Time.deltaTime;
            FlameRing.SetActive(true);
            Debug.Log(FlameRingTimer);
            Debug.Log("Turn on");
            if (FlameRingTimer <= 0)
            {
                Debug.Log("Turn off");
                FlameRing.SetActive(false);
                FlameRingAttack = false;
                FlameRingTimer = 20.0f;
                DemonSummonAttack = true;
                AttackTimer = 4.0f;
            }
        }
    }

    void SecondAttack()
    {
        AttackTimer -= Time.deltaTime;
        if (AttackTimer <= 0)
        {
            DemonAttackTimer -= Time.deltaTime;
            if (DemonAttackTimer <= 0)
            {
                DemonSummonAttack = false;
                FlameRingAttack = true;
                AttackTimer = 4.0f;
                return;
            }
            if (demonSpawnTime == 5f)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector3 pos = new Vector3(Random.Range(transform.position.x - 1f, transform.position.x + 1f),
                        Random.Range(transform.position.y + 1f, transform.position.y - 0.7f));
                    Instantiate(DemonPortalSummon, pos, Quaternion.identity);
                }
            }
            demonSpawnTime -= Time.deltaTime;
            if (demonSpawnTime <= 0)
            {
                demonSpawnTime = 5f;
            }
        }
    }

    void ThirdAttack()
    {

    }

    protected override void Die()
    {
        base.Die();
        AudioController.instance.PlaySFX("BossDie");
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
            AudioController.instance.PlaySFX("Orge");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, triggerLenght);
    }
}
