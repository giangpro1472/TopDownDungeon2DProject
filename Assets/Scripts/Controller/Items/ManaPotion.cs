using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Inventory/Potion/ManaPotion")]
public class ManaPotion : Potion
{
    protected override void Effect()
    {
        Debug.Log("Mana Recovery: " + recovery);
    }
}
