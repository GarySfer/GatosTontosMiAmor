using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Inventory inventory;
    private void Awake()
    {
        Inventory inventory = new Inventory();
    }

    public void AddItemToInventory(Item item)
    {
        inventory.AddItem(item);
    }
    private void RemoveItemFromInventory()
    {
        
    }
}
