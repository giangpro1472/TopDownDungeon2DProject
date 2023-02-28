using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Inventory/Potion/HealthPotion")]
public class HealthPotion : Potion
{
    protected override void Effect()
    {
        Player.Instance.hpController.Healing(recovery);
        Debug.Log("Heal: " + recovery);
    }
}
