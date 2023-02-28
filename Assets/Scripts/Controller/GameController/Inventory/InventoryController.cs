using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
	#region Singleton
	public static InventoryController Instance;
	void Awake()
	{
		if (InventoryController.Instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			Destroy(gameObject);
			return;
		}
		Instance = this;
	}

	#endregion

	public List<Item> items;
	public int space = 18;

    public bool AddItemIntoInventoryList(Item item)
	{
        if (items.Count > space)
        {
			Debug.Log("Inventory het cho");
        }
        else
        {
			if (!item.isInInventory)
			{
				item.amount++;
				item.isInInventory = true;
				items.Add(item);
				GameManager.instance.SaveListItem();
				return true;
			}
            else
            {
				foreach (Item itemList in items)
				{
                    if (item.ID == itemList.ID)
                    {
						itemList.amount++;
						return true;
                    }
				}
			}   
        }
		return false;
	}

	public bool RemoveItemFromList(Item item)
	{
		foreach (Item itemList in items)
		{
			if (itemList.ID == item.ID)
			{
				if (itemList.isStackable)
				{
					if (itemList.amount > 1)
					{
						itemList.amount--;
						return true;
					}
				}
				itemList.amount--;
				itemList.isInInventory = false;
				items.Remove(itemList);
				GameManager.instance.RemoveItemFromList();
				return true;
			}
		}
		return false;
	}
}
   

