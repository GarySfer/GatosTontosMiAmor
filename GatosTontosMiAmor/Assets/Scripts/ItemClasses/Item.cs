namespace DefaultNamespace.ItemClasses
{
    public abstract class Item
    {
        // change all private to protected
        private string _name;
        private string _description;
        private int _value;
        
        // private int _moveSpeed;
        // private int _attackSpeed;
        // private int _attackDamage;
        // private int _health;

        public enum ItemType
        {
            AbilityItem,
            WeaponItem,
        }
        
        public Item(string name, string description, int value)
        {
            _name = name;
            _description = description;
            _value = value;
        }
    }
}