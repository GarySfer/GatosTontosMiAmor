using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Sword,
        Shield,
        AbilityItem,
        HealthPotion,
    }
    public ItemType itemType;

    private string _name;

    public Item(string name)
    {
        this._name = name;
    }
}
