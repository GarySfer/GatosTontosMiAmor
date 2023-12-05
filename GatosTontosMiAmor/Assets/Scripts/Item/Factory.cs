using Item.Models;
using Item.templates;

namespace Item
{
    public static class Factory
    {
        public static ItemModel Create(TemplateItem templateItem)
        {
            if (templateItem is WeaponTemplateItem weaponTemplateItem)
            {
                if (templateItem is SwordTemplate swordTemplate)
                {
                    return new SwordModel(swordTemplate, 10);
                }
                
                return new WeaponItemModel(weaponTemplateItem, 10);
            }
            // the same for other types of items
            
            
            return null;
        }
    }
}