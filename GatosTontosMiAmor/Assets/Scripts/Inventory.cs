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
    public float healthPotionCooldownSeconds = 4;
    public float currentHealthPotionCooldownSeconds;
    public int healthPotionHealAmount = 50;
    private int coins;
    private int startingCoins = 0;

    private ItemManager _itemManager = ItemManager.Instance;

    private List<WeaponItemModel> _equippedWeaponItems = new(2);
    // private HyperAblilityItem _hyperAblilityItem;
    // private List<ActiveAbilityItem> _equippedActiveAbilityItems = new(2);
    // private List<PassiveAbilityItem> _equippedPassiveAbilityItems = new(2);

    public event Action<int> OnMoneyChange = delegate { };


    public Inventory()
    {
        Debug.Log(_equippedWeaponItems);
        Debug.Log("Inventory");
        
        _equippedWeaponItems.Add(null);
        _equippedWeaponItems.Add(null);
    }

    public void AddItem(ItemModel itemModel, int slot)
    {
        // todo adding an item to inventory throws an index out of range exception for slot - not anymore i dont think
        if (itemModel is WeaponItemModel weaponItemModel)
        {
            if (slot < 0 || slot >= _equippedWeaponItems.Capacity)
            {
                Debug.Log("Invalid slot");
                return;
            }

            Debug.Log(_equippedWeaponItems.Count);
            
            if (_equippedWeaponItems[slot] == null)
            {
                _equippedWeaponItems[slot] = weaponItemModel;
                Debug.Log("weaponItems amount: "+_equippedWeaponItems[slot]);
                return;
            }

            ItemModel replacedItem = ReplaceItem(slot, weaponItemModel);
            DropItem(replacedItem);
        }

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
    
    public void UseHealthPotion()
    {
        if (currentHealthPotionCooldownSeconds <= 0)
        {
            currentHealthPotionCooldownSeconds = healthPotionCooldownSeconds;
            GameManager.Instance.player.GetComponent<Health>().Heal(healthPotionHealAmount);
        }
    }
    
}