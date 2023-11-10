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
    public int startingCoins = 0;

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

    public void AddItem(Item item)
    {
    }

    public bool RemoveItem(Item item)
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
}