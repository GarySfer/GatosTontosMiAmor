using Item.Models;
using Item.templates;
using UnityEngine;

namespace Item
{
    public class ItemManager : MonoBehaviour
    {
        // singleton
        public static ItemManager Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
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