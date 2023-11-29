using System;
using System.Collections;
using System.Collections.Generic;
using Item;
using Item.Models;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class Inventory
{
    // TODO add max health potions to the upgrade shop and then update how many health potions the player can have
    private int maxHealthPotions = 4;
    private int coins = 0;
    private int startingCoins = 0;
    
    private ItemManager _itemManager = ItemManager.Instance; 

    private List<WeaponItemModel> _equippedWeaponItems = new(2);
    // private HyperAblilityItem _hyperAblilityItem;
    // private List<ActiveAbilityItem> _equippedActiveAbilityItems = new(2);
    // private List<PassiveAbilityItem> _equippedPassiveAbilityItems = new(2);

    public event Action<int> OnMoneyChange = delegate { };


    public Inventory()
    {
        // Debug.Log(_equippedWeaponItems);
        Debug.Log("Inventory");
    }

    public void AddItem(ItemModel itemModel,int slot)
    {
        if (itemModel is WeaponItemModel weaponItemModel)
        {
            ItemModel replacedItem = ReplaceItem(slot, weaponItemModel);
            DropItem(replacedItem);
            // _equippedWeaponItems[slot] = weaponItemModel;
        }
        
        
        // TODO add item to inventory
    }

    private ItemModel ReplaceItem(int slot, ItemModel itemModel)
    {
        if (itemModel is WeaponItemModel weaponItemModel)
        {
            ItemModel oldItem = _equippedWeaponItems[slot];
            _equippedWeaponItems[slot] = weaponItemModel;
            return oldItem;
        }
        
        return null;
    }
    
    

    public void DropItem(ItemModel itemModel)
    {
        // TODO drop/salvage item from inventory
        _itemManager.createItemInWorld(itemModel, GameManager.Instance.player.transform);
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

    public int GetCoins()
    {
        return startingCoins;
    }
}