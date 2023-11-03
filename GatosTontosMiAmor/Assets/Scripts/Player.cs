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
        inventory = new Inventory();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth(int newHealth)
    {
        Health += newHealth;
    }
    public void AddCoins(int newCoins)
    {
        
    }



    public void RemoveItemFromInventory()
    {
        
    }
    
    
    
}
