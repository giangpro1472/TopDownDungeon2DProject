using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWeapon : WeaponController
{
    public float mana;
    [SerializeField]
    Transform shootPos;
    bool isAttack;


    

    protected override void Start()
    {
        base.Start();
    }

    protected override void SetWeapon()
    {
        base.SetWeapon();
        mana = weaponScripted.mana;
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Player.Instance.manaController.currentValue >= mana)
            {
                if (Time.time - lastAttack > cooldown)
                {
                    lastAttack = Time.time;
                    Player.Instance.manaController.UseSpell(mana);
                    Attack();
                }
            }
            else
            {
                Debug.Log("Het mana");
            }
        }
    }

    public virtual void ShootMagicProjectile()
    {
        WaterBoltProjectile waterbolt = Create.Instance.CreateWalterBolt(shootPos);
        waterbolt.damage = damage;
    }
}
