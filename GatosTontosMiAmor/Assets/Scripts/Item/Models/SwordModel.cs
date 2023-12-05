using System;
using Item.templates;
using UnityEngine;

namespace Item.Models
{
    public class SwordModel : WeaponItemModel
    {
        public SwordModel(WeaponTemplateItem baseModel, int weaponDamage) : base(baseModel, weaponDamage)
        {
            WeaponType weaponType = WeaponType.Sword;
        }

        // todo should this be here?
        public void Attack()
        {
            throw new NotImplementedException();
        }
    }
}