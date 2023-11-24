using Unity.VisualScripting;
using UnityEngine;

namespace Item
{
    public class WeaponItemModel : ItemModel
    {
        public int weaponDamage;
        public WeaponType weaponType { get; private set; }

        public WeaponItemModel(WeaponTemplateItem baseModel, int weaponDamage) : base(baseModel)
        {
            weaponType = baseModel.weaponType;
            this.weaponDamage = weaponDamage;
        }
    }
}