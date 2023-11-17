using System;
using UnityEngine.Serialization;

namespace DefaultNamespace.ItemClasses
{
    [Serializable]
    public class ActiveAbilityItem : AbilityItem
    {
        private int _cooldown;
        [FormerlySerializedAs("abilityItemType")] public AbilityItemType2 abilityItemType2;

        public ActiveAbilityItem(string name, string description, int value, int moveSpeed, int attackSpeed,
            int attackDamage, int health, int cooldown) : base(name, description, value, moveSpeed, attackSpeed,
            attackDamage, health)
        {
            _cooldown = cooldown;
            abilityItemType2 = AbilityItemType2.ActiveAbilityItem;
        }

        public void activateItem() {}
    }
}