using UnityEngine;

public class ItemPickup : Interactable
{
    public ItemInfo item;

    public override void Interact()
    {
        base.Interact();
        Pickup();
    }

    void Pickup()
    {
        Debug.Log("Picking up item. name : " + name);

        bool wasPickedUp = PlayerInventory.Instance.AddItem(item);

        if(wasPickedUp)
            Destroy(gameObject);
    }
}
