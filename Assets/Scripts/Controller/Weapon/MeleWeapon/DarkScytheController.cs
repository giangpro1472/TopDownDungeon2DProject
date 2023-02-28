using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkScytheController : SwordController
{
    [SerializeField]
    protected Transform shootPos;
    
    public virtual void ShootProjectile()
    {
        DarkCytheProjectile attack = Create.Instance.CreateDarkScytheAttack(shootPos);
        attack.damage = damage * 2;
    }

    protected override void Attack()
    {
        AudioController.instance.PlaySFX("DarkSickel");
        base.Attack();
    }
}
