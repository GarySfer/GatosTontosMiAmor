using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health;
    public int Coins;
    public int Gems;


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
        Coins += newCoins;
    }

    public void AddItemToInventory()
    {
        
    }

    public void RemoveItemFromInventory()
    {
        
    }
    
    
    
}
