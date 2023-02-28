using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    [SerializeField] private List<Item> itemDatabase;

   
    //[ContextMenu("Set IDs")]
    //public void SetItemID()
    //{
    //    itemDatabase = new List<Item>();
    //    var foundItems = Resources.LoadAll<Item>(path: "Items").OrderBy(i => i.ID).ToList();

    //    var hasIDInRange = foundItems.Where(i => i.ID != -1 && i.ID < foundItems.Count).OrderBy(i => i.ID).ToList();
    //    var hasIDNotInRange = foundItems.Where(i => i.ID != -1 && i.ID >= foundItems.Count).OrderBy(i => i.ID).ToList();
    //    var noID = foundItems.Where(i => i.ID <= -1).OrderBy(i => i.ID).ToList();

    //    var index = 0;
    //    for (int i = 0; i < foundItems.Count; i++)
    //    {
    //        Item itemToAdd;
    //        itemToAdd = hasIDInRange.Find(d => d.ID == i);

    //        if (itemToAdd != null)
    //        {
    //            itemDatabase.Add(itemToAdd);
    //        }
    //        else if (index < noID.Count)
    //        {
    //            noID[index].ID = i;
    //            itemToAdd = noID[index];
    //            index++;
    //            itemDatabase.Add(itemToAdd);
    //        }
    //    }

    //    foreach (var item in hasIDNotInRange)
    //    {
    //        itemDatabase.Add(item);
    //    }
    //}

    //public Item GetItem(int id)
    //{
    //    return itemDatabase.Find(i => i.ID == id);
    //}

}
