using System;
using UnityEngine;

namespace ItemSOs
{
    [CreateAssetMenu(fileName = "New Weapon Item", menuName = "Inventory/Items/Weapons")]
    public class WeaponItem : ItemSO
    {
        public int damage;
        public void Awake()
        {
            ItemType = ItemType.Weapon;
        }
    }
}