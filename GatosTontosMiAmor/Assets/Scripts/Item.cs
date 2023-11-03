using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        SmallSword,
        BigSword,
        SmallShield,
        BigShield,
        HealthPotion,
        Chip,
    }

    public ItemType itemType;
    public int amount;

}