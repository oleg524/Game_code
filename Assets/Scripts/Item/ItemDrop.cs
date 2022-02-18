using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();

    public void ItemDroping()
    {
        int ID = RandomItemID();

    }

    private int RandomItemID()
    {
        int RandomID = Random.Range(1, items.Count + 1);

        return RandomID;
    }
}
