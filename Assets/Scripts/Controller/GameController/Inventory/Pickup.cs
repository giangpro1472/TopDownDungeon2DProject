using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Collideable
{
    public Item item;
    protected override void Start()
    {
        base.Start();
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            InventoryController.Instance.AddItemIntoInventoryList(item);
            InventoryUI.Instance.UpdateInventory(item);
            Destroy(gameObject);
        }
    }
}
