using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.ItemClasses;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory
{
    // TODO add max health potions to the upgrade shop and then update how many health potions the player can have
    private int maxHealthPotions = 4;
    private int coins = 0;
    private int startingCoins = 0;

    private List<WeaponItem> _equippedWeaponItems = new(2);
    private HyperAblilityItem _hyperAblilityItem;
    private List<ActiveAbilityItem> _equippedActiveAbilityItems = new(2);
    private List<PassiveAbilityItem> _equippedPassiveAbilityItems = new(2);

    public event Action<int> OnMoneyChange = delegate { };


    public Inventory()
    {
        Debug.Log(_equippedWeaponItems);
        Debug.Log("Inventory");
    }

    public void AddItem(Item item, int slot)
    {
        // dont look at this, this was made with too much background noise in class
        var weaponItem = item as WeaponItem;
        if (weaponItem != null && weaponItem.ItemType2 == Item.ItemType2.WeaponItem)
        {
            if (_equippedWeaponItems[slot] == null)
            {
                _equippedWeaponItems[slot] = weaponItem;
                return;
            }

            DropItem(weaponItem);
            _equippedWeaponItems[slot] = weaponItem;
        }

        var abilityItem = item as AbilityItem;
        if (abilityItem != null && abilityItem.ItemType2 == Item.ItemType2.AbilityItem)
        {
            var activeAbilityItem = item as ActiveAbilityItem;
            if (activeAbilityItem.abilityItemType2 == AbilityItem.AbilityItemType2.ActiveAbilityItem)
            {
                if (_equippedActiveAbilityItems[slot] == null)
                {
                    _equippedActiveAbilityItems[slot] = activeAbilityItem;
                    return;
                }

                DropItem(activeAbilityItem);
                _equippedActiveAbilityItems[slot] = activeAbilityItem;
            }

            var passiveAbilityItem = item as PassiveAbilityItem;
            if (passiveAbilityItem.AbilityItemType2 == AbilityItem.AbilityItemType2.PassiveAbilityItem)
            {
                if (_equippedPassiveAbilityItems[slot] == null)
                {
                    _equippedPassiveAbilityItems[slot] = passiveAbilityItem;
                    return;
                }

                DropItem(passiveAbilityItem);
                _equippedPassiveAbilityItems[slot] = passiveAbilityItem;
            }

            var hyperAbilityItem = item as HyperAblilityItem;
            if (hyperAbilityItem.AbilityItemType2 == AbilityItem.AbilityItemType2.HyperAbilityItem)
            {
                // add to empty hyper ability slot or try to replace a hyper ability in the slot
                if (_hyperAblilityItem == null)
                {
                    _hyperAblilityItem = hyperAbilityItem;
                    
                }
                else
                {
                    // replace hyper ability
                }
            }
        }
    }


    public bool DropItem(Item item)
    {
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

    public int GetCoins()
    {
        return startingCoins;
    }
}