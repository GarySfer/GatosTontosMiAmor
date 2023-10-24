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
    }

    public ItemType itemType;
    public int amount;

}
