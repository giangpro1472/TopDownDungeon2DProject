using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemParent;

    [SerializeField]
    InventoryController inventory;

    [SerializeField]
    InventorySlot[] slots;

    public static InventoryUI Instance;

    void Start()
    {
        Instance = this;
        slots = itemParent.GetComponentsInChildren<InventorySlot>();
    }

    public void UpdateInventory(Item item)
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (slots[i].item != null)
            {
                if (inventory.items[i].isStackable && inventory.items[i].ID == item.ID)
                {
                    if (inventory.items[i].amount <= 1)
                    {
                        slots[i].itemAmountText.enabled = false;
                    }
                    else
                    {
                        slots[i].itemAmountText.enabled = true;
                        slots[i].itemAmountText.text = inventory.items[i].amount.ToString();
                    }
                    break;
                }
            }
            else
            {
                slots[i].removeButton.interactable = true;
                slots[i].AddItem(inventory.items[i]);
                if (slots[i].item.amount > 1)
                {
                    slots[i].itemAmountText.enabled = true;
                    slots[i].itemAmountText.text = inventory.items[i].amount.ToString();
                }
                Instantiate(inventory.items[i].itemButton, slots[i].transform, false);
                break;
            }
        }
    }

    public void RemoveFromInventoryUI(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                if (slots[i].item.ID == item.ID)
                {
                    if (item.isStackable)
                    {
                        if (item.amount > 1)
                        {
                            slots[i].itemAmountText.text = inventory.items[i].amount.ToString();
                            break;
                        }
                        else if (item.amount == 1)
                        {
                            slots[i].itemAmountText.enabled = false;
                            break;
                        }
                        else if (item.amount == 0)
                        {
                            foreach (Transform child in slots[i].transform)
                            {
                                Debug.Log("Remove item UI from slot: " + i);
                                slots[i].itemAmountText.enabled = false;
                                slots[i].removeButton.interactable = false;
                                slots[i].item = null;
                                GameObject.Destroy(child.gameObject);
                            }
                        }
                    }
                    else
                    {
                        foreach (Transform child in slots[i].transform)
                        {
                            Debug.Log("Remove item UI from slot: " + i);
                            slots[i].itemAmountText.enabled = false;
                            slots[i].removeButton.interactable = false;
                            slots[i].item = null;
                            GameObject.Destroy(child.gameObject);
                        }
                    }

                    for (int j = i; j < slots.Length - 1; j++)
                    {
                        if (slots[j + 1].item == null)
                        {
                            foreach (Transform child in slots[j].transform)
                            {
                               slots[j].itemAmountText.enabled = false;
                               slots[j].removeButton.interactable = false;
                               slots[j].item = null;
                               GameObject.Destroy(child.gameObject);
                               break;
                            }
                        }
                        else
                        {
                            foreach (Transform child in slots[j].transform)
                            {
                                GameObject.Destroy(child.gameObject);
                            }
                            slots[j].itemAmountText.enabled = slots[j + 1].itemAmountText.enabled;
                            slots[j].itemAmountText.text = slots[j + 1].itemAmountText.text;
                            slots[j].removeButton.interactable = slots[j + 1].removeButton.interactable;
                            slots[j].item = slots[j + 1].item;
                            Instantiate(slots[j + 1].item.itemButton, slots[j].transform, false);
                            Debug.Log("Item hien tai o trong slot " + j + " la: " + slots[j].item.name);
                        }
                    }
                }
              
            }
        }

    }
}
