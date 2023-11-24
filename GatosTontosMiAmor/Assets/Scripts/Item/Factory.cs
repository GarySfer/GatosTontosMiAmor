namespace Item
{
    public static class Factory
    {
        public static ItemModel Create(TemplateItem templateItem)
        {
            WeaponTemplateItem weaponTemplateItem = templateItem as WeaponTemplateItem;
            if (weaponTemplateItem != null)
            {
                return new WeaponItemModel(weaponTemplateItem, 10);
            }

            return null;
        }
    }
}