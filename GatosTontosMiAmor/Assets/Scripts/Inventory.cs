using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.SmallSword, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.SmallShield, amount = 1 });

        Debug.Log("Inventory");
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }
}