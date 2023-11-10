using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory { get; private set; }
    
    // stats
    private int _moveSpeed;
    private int _attackSpeed;
    private int _attackDamage;
    private int _health;
    private int _maxHealth;
    

    private void Awake()
    {
        GameManager.Instance.player = this;
        inventory = new Inventory();
    }

    public void AddHealth(int newHealth)
    {
        _health += newHealth;
    }
    
    public void RemoveHealth(int newHealth)
    {
        _health -= newHealth;
    }
    
}
