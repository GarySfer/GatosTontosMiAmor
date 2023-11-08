using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> itemList;

    // TODO add max health potions to the upgrade shop and then update how many health potions the player can have
    private int maxHealthPotions = 4;
    private int coins = 0;


    public int startingCoins {get; private set;} = 4;
    public event Action<int> OnMoneyChange = delegate {  }; 
    

    void Start() {
        AddCoins(startingCoins);
    }

    public Inventory()
    {
        itemList = new List<Item>();


        // starter items example
        AddItem(new Item { itemType = Item.ItemType.SmallSword, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.SmallShield, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 2 });


        Debug.Log("Inventory");
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        // if player has more than x health potions cancel adding more potions
        if (item.itemType == Item.ItemType.HealthPotion)
        {
            // if player has more than maxHealthPotions cancel adding more potions
            if (itemList.FindAll(x => x.itemType == Item.ItemType.HealthPotion).Count >= maxHealthPotions)
            {
                return;
            }
        }

        // if item already exists in inventory add to amount
        if (itemList.Exists(x => x.itemType == item.itemType))
        {
            itemList.Find(x => x.itemType == item.itemType).amount += item.amount;
        }
        else
        {
            itemList.Add(item);
        }        
    }

    public bool RemoveItem(Item item)
    {
        if (itemList.Contains(item))
        {
            itemList.Remove(item);
            return true;
        }
        Debug.Log("Item not found");
        return false;
    }

    public void AddCoins(int newCoins)
    {
        coins += newCoins;
        OnMoneyChange(coins);
    }
    
    public bool RemoveCoins(int newCoins)
    {
        if (coins - newCoins < 0)
        {
            Debug.Log("Not enough coins");
            return false;
        }
        coins -= newCoins;
        OnMoneyChange(coins);
        return true;

    }
}