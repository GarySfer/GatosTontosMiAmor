namespace DefaultNamespace.ItemClasses
{
    public abstract class AbilityItem : Item
    {
        private int _moveSpeed;
        private int _attackSpeed;
        private int _attackDamage;
        private int _health;
        public ItemType2 ItemType2;
        
        public enum AbilityItemType2
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
            ItemType2 = ItemType2.AbilityItem;
        }
    }
}