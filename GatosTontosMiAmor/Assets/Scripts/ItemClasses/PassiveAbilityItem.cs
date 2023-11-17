namespace DefaultNamespace.ItemClasses
{
    public abstract class PassiveAbilityItem : AbilityItem
    {
        public AbilityItemType2 AbilityItemType2;
        public PassiveAbilityItem(string name, string description, int value, int moveSpeed, int attackSpeed, int attackDamage, int health) : base(name, description, value, moveSpeed, attackSpeed, attackDamage, health)
        {
            AbilityItemType2 = AbilityItemType2.PassiveAbilityItem;
        }
    }
}