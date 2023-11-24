using Unity.VisualScripting;
using UnityEngine;
namespace Item
{
    public class WeaponItemModel : ItemModel
    {
        public int weaponDamage;
        public WeaponItemModel(TemplateItem baseModel, int weaponDamage) : base(baseModel)
        {
            this.weaponDamage = weaponDamage;
        }
    }
}