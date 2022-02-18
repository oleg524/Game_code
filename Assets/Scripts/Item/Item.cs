using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public string ID = "";

    public virtual void Use()
    {
        //Debug.Log("USING" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
        
    }
}
