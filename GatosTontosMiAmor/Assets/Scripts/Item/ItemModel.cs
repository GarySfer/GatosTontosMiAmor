using System.IO;
using UnityEngine;

namespace Item
{
    public class ItemModel : Model
    {
        public Sprite sprite;
        public string name;
        public TemplateItem baseModel { get; private set; }

        public ItemModel(TemplateItem baseModel)
        {
            this.baseModel = baseModel;
            sprite = baseModel.sprite;
            name = baseModel.name;
        }
    }
}