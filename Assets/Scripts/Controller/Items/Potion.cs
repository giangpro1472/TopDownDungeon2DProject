using UnityEngine;

public class Potion : Item
{
    public float recovery;

    public override void Use()
    {
       bool use = InventoryController.Instance.RemoveItemFromList(this);
       if (use)
       {
            Effect();
            FindObjectOfType<AudioController>().PlaySFX("Heal");
            InventoryUI.Instance.RemoveFromInventoryUI(this);
       } 
    }

    protected virtual void Effect()
    {
    }

}
