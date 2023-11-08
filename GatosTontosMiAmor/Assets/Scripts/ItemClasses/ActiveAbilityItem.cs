namespace DefaultNamespace.ItemClasses
{
    public class ActiveAbilityItem : Item
    {
        private int _cooldown;

        public ActiveAbilityItem(string name, string description, int value, int cooldown) : base(name, description, value)
        {
            _cooldown = cooldown;
        }
    }
}