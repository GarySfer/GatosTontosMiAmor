using System;
using System.Collections;
using System.Collections.Generic;
using Item;
using Item.Models;
using Item.templates;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ItemModel swordModel = Factory.Create(new SwordTemplate());
            GameManager.Instance.player.inventory.AddItem(swordModel,1);
        }
    }
}
