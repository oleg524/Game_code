using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("So Much");
            return;
        }
        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    public int spase = 20;
    public bool Add(Item item)
    {

        if (items.Count >= spase)
        {
            Debug.Log("Not enoough room");
            return false;
        }
        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
