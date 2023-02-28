using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class WeaponController : Collideable
{
    public WeaponScripted weaponScripted;
    public SpriteRenderer weaponSprite;
    protected Animator anim;

    protected float cooldown;
    protected float lastAttack;

    public float damage;
    public float knockbackForce;
    public int price;

    protected override void Start()
    {
        base.Start();
        SetWeapon();
        weaponSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected virtual void SetWeapon()
    {
        damage = weaponScripted.damage;
        knockbackForce = weaponScripted.knockBackForce;
        cooldown = weaponScripted.cooldown;
        price = weaponScripted.price;
    }
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastAttack > cooldown)
            {
                lastAttack = Time.time;
                Attack();
            }
        }
    }
    protected virtual void Attack()
    {
        anim.SetTrigger("Attack");
    }

}

public class Weapon : SingletonMonoBehaviour<WeaponController>
{

}

