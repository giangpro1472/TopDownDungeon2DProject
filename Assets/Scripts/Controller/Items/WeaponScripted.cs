using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Weapon")]
public class WeaponScripted : Item
{
    public float damage;
    public float knockBackForce;
    public float mana;

    public float cooldown;
    public int price;

    public bool isEquiped;
}
