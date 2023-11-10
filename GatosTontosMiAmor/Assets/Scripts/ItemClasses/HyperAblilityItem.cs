namespace DefaultNamespace.ItemClasses
{
    public abstract class HyperAblilityItem : PassiveAbilityItem
    {
        public AbilityItemType abilityItemType;

        public HyperAblilityItem(string name, string description, int value, int moveSpeed, int attackSpeed, int attackDamage, int health) : base(name, description, value, moveSpeed, attackSpeed, attackDamage, health)
        {
            abilityItemType = AbilityItemType.HyperAbilityItem;
        }

        // active ability
    }
}