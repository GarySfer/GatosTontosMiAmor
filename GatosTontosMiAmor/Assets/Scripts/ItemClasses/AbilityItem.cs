namespace DefaultNamespace.ItemClasses
{
    public abstract class AbilityItem : Item
    {
        private int _moveSpeed;
        private int _attackSpeed;
        private int _attackDamage;
        private int _health;
        public ItemType itemType;
        
        public enum AbilityItemType
        {
            PassiveAbilityItem,
            ActiveAbilityItem,
            HyperAbilityItem,
        }

        public AbilityItem(string name, string description, int value, int moveSpeed, int attackSpeed, int attackDamage, int health) : base(name, description, value)
        {
            _moveSpeed = moveSpeed;
            _attackSpeed = attackSpeed;
            _attackDamage = attackDamage;
            _health = health;
            itemType = ItemType.AbilityItem;
        }
    }
}