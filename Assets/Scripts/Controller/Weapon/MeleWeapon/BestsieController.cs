using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestsieController : DarkScytheController
{
    [SerializeField]
    Transform shootPos2;

    [SerializeField]
    Transform shootPos3;
    public override void ShootProjectile()
    {
        BestsyWrathProjectile attack = Create.Instance.CreateBestsyAttack(shootPos);
        BestsyWrathProjectile attack1 = Create.Instance.CreateBestsyAttack(shootPos2);
        BestsyWrathProjectile attack2 = Create.Instance.CreateBestsyAttack(shootPos3);
        attack.damage = damage + 5;
        attack1.damage = damage + 5;
        attack2.damage = damage +5;
    }
}
