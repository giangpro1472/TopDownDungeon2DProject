using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Button removeButton;
    public TextMeshProUGUI itemAmountText;
    public Item item;
    public int index;

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void RemoveItem()
    {
        InventoryController.Instance.RemoveItemFromList(item);
        InventoryUI.Instance.RemoveFromInventoryUI(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            Debug.Log("Use Item: " + item.name);
            item.Use();
        }
        
    }
}
