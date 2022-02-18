using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }
    void PickUp()
    {
        Debug.Log("Picing Item" + item.name);

        bool WasPickedUp = Inventory.instance.Add(item);

        if(WasPickedUp)
            Destroy(gameObject);
    }
}  