namespace DefaultNamespace.ItemClasses
{
    public abstract class ActiveAbilityItem : AbilityItem
    {
        private int _cooldown;

        protected ActiveAbilityItem(string name, string description, int value, int moveSpeed, int attackSpeed, int attackDamage, int health, int cooldown) : base(name, description, value, moveSpeed, attackSpeed, attackDamage, health)
        {
            _cooldown = cooldown;
        }
    }
}