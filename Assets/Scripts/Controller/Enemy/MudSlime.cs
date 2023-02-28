using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudSlimeInfo
{
    public float HP;
    public float speed;
    public float damage;
}
public class MudSlime : EnemyController
{
    [SerializeField]
    SmallMudSlime smallMudSlime;

    public static List<MudSlime> mudSlimes = new List<MudSlime>();

    protected override void Start()
    {
        base.Start();
        mudSlimes.Add(this);
    }

    private void OnDestroy()
    {
        mudSlimes.Remove(this);
    }

    protected override void FixedUpdate()
    {
        if (Vector3.Distance(Player.Instance.transform.position, startingPosition) < triggerLenght)
        {
            playerDitected = true;
        }

        if (playerDitected)
        {
            EnemyAI();
            Debug.Log("Chasing Player");
        }

        if (Player.Instance.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1.6f, 1.6f, 1.6f);
        }
        else
        {
            transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
        }
        EnemyDamage();
    }

    protected override void EnemyAI()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) > 0.15f)
        {
            ProjectTileMove((Player.Instance.transform.position - transform.position).normalized);
        }
        else
        {
            Debug.Log("Attack");
        }
    }

    protected override void Die()
    {
        base.Die();
        Instantiate(smallMudSlime, transform.position + new Vector3(0, 0.1f), transform.rotation);
        Instantiate(smallMudSlime, transform.position + new Vector3(0.1f, 0), transform.rotation);
        Instantiate(smallMudSlime, transform.position + new Vector3(-0.1f, 0.1f), transform.rotation);
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
            AudioController.instance.PlaySFX("MudSlime");
        }

    }


}
