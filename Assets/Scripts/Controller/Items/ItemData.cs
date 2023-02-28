using UnityEngine;

[System.Serializable]
public class ItemData 
{
    public int ID;
    public string name = "Item Name";
    public int amount;
    public bool isStackable;
    public bool isInInventory;

    public ItemData(Item item)
    {
        ID = item.ID;
        name = item.name;
        amount = item.amount;
        isInInventory = item.isInInventory;
        isStackable = item.isStackable;
    }
}
