using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int ID;
    new public string name = "Item Name";
    public GameObject itemButton = null;
    public bool isStackable;
    public bool isInInventory;
    public int amount;

    public virtual void Use()
    {
        Debug.Log("Use " +name);
    }
}
