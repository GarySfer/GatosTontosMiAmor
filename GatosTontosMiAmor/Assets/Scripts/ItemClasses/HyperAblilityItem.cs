namespace DefaultNamespace.ItemClasses
{
    public abstract class HyperAblilityItem : PassiveAbilityItem
    {
        public AbilityItemType2 AbilityItemType2;

        public HyperAblilityItem(string name, string description, int value, int moveSpeed, int attackSpeed, int attackDamage, int health) : base(name, description, value, moveSpeed, attackSpeed, attackDamage, health)
        {
            AbilityItemType2 = AbilityItemType2.HyperAbilityItem;
        }

        // active ability
    }
}