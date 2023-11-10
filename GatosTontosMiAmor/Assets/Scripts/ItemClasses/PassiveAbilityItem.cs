namespace DefaultNamespace.ItemClasses
{
    public abstract class PassiveAbilityItem : AbilityItem
    {
        public PassiveAbilityItem(string name, string description, int value, int moveSpeed, int attackSpeed, int attackDamage, int health) : base(name, description, value, moveSpeed, attackSpeed, attackDamage, health)
        {
            
        }
    }
}