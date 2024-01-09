using UnityEngine;

namespace Item.templates
{
    public class WeaponTemplateItem : TemplateItem
    {
        [field: SerializeField] public ItemType itemType { get; private set; }
    }
}