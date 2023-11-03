using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health;
    public Inventory inventory { get; private set; }
    

    private void Awake()
    {
        GameManager.Instance.player = this;
        inventory = new Inventory();
    }

    public void AddHealth(int newHealth)
    {
        Health += newHealth;
    }
    
    public void RemoveHealth(int newHealth)
    {
        Health -= newHealth;
    }
    
}
