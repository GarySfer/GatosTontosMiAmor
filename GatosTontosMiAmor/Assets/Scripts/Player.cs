using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health;
    private Inventory inventory;
    

    private void Awake()
    {
        // gameManager.Player = this;
        inventory = new Inventory();
    }

    public void AddHealth(int newHealth)
    {
        Health += newHealth;
    }
    
}
