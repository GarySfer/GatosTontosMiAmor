using UnityEngine;

namespace Item
{
    public class WeaponTemplateItem : TemplateItem
    {
        [field: SerializeField] public WeaponType weaponType { get; private set; }
    }
}