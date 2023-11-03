using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;
    private int maxHealthPotions = 5;

    public Inventory()
    {
        itemList = new List<Item>();

        
        // starter items example
        AddItem(new Item { itemType = Item.ItemType.SmallSword, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.SmallShield, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Coin, amount = 100 });
        AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 2 });
        
        
        Debug.Log("Inventory");
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        // if player has more than x health potions cancel adding more potions
        if (item.itemType == Item.ItemType.HealthPotion)
        {
            if (itemList.Count >= maxHealthPotions)
            {
                return;
            }
        }

        itemList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }
}