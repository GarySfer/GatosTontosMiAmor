using Item.Models;
using Item.templates;
using UnityEngine;

namespace Item
{
    public class ItemManager : MonoBehaviour
    {
        // singleton
        private static ItemManager _instance;
        public static ItemManager Instance => _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public void createItem(TemplateItem templateItem, Transform transform)
        {
            ItemModel item = Factory.Create(templateItem);
            createItemInWorld(item, transform);
        }

        public void createItemInWorld(ItemModel itemModel, Transform transform)
        {
            GameObject item = new GameObject(itemModel.name);
            item.AddComponent<SpriteRenderer>().sprite = itemModel.sprite;
            Instantiate(item, transform.position, transform.rotation);
        }
    }
}