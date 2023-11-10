using DefaultNamespace.ItemClasses;

namespace DefaultNamespace
{
    public class Bomb : ActiveAbilityItem
    {
        public Bomb(string name, string description, int value, int moveSpeed, int attackSpeed, int attackDamage,
            int health, int cooldown) : base(name, description, value, moveSpeed, attackSpeed, attackDamage, health,
            cooldown)
        {
        }

        // this is an example item
        public override void activateItem()
        {
            throw new System.NotImplementedException();
        }
    }
}