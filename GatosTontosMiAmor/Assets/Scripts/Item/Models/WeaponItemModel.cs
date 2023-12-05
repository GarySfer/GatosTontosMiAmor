using Item.templates;

namespace Item.Models
{
    public class WeaponItemModel : ItemModel
    {
        public int weaponDamage;
        public ItemType itemType { get; private set; }

        public WeaponItemModel(WeaponTemplateItem baseModel, int weaponDamage) : base(baseModel)
        {
            itemType = baseModel.itemType;
            this.weaponDamage = weaponDamage;
        }
    }
}