namespace DefaultNamespace.ItemClasses
{
    public abstract class WeaponItem : Item
    {
        private int _damage;
        private int _attackSpeed;
        private int _comboCount;
        public ItemType itemType;
        private WeaponType _weaponType;
        public enum WeaponType
        {
            Melee,
            Ranged,
            Shield,
        }

        protected WeaponItem(string name, string description, int value, int damage, int attackSpeed, int comboCount, WeaponType weaponType) : base(name, description, value)
        {
            _damage = damage;
            _attackSpeed = attackSpeed;
            _comboCount = comboCount;
            itemType = ItemType.WeaponItem;
            _weaponType = weaponType;
        }
    }
}