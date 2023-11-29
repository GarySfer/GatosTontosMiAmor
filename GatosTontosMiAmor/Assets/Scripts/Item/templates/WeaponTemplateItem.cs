using UnityEngine;

namespace Item.templates
{
    public class WeaponTemplateItem : TemplateItem
    {
        [field: SerializeField] public WeaponType weaponType { get; private set; }
    }
}