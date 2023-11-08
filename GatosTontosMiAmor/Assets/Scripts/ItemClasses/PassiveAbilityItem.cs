namespace DefaultNamespace.ItemClasses
{
    public class PassiveAbilityItem : Item
    {
        private int _moveSpeed;
        private int _attackSpeed;
        private int _attackDamage;
        private int _health;

        public PassiveAbilityItem(string name, string description, int value, int moveSpeed, int attackSpeed, int attackDamage, int health) : base(name, description, value)
        {
            _moveSpeed = moveSpeed;
            _attackSpeed = attackSpeed;
            _attackDamage = attackDamage;
            _health = health;
        }
        
        
    }
}