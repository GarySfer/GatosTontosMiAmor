using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.ItemClasses;
using UnityEngine;

public enum ItemType
{
    Weapon,
    ActiveAbility,
    PassiveAbility,
    HyperAbility
}

public abstract class ItemSO : ScriptableObject
{
    public Sprite Sprite;
    public ItemType ItemType;

}