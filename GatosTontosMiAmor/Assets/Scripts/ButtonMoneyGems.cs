using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class ButtonMoney : MonoBehaviour
{
    private Inventory inventoryGet => GameManager.Instance.inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoneyOnClick() {
        inventoryGet.AddCoins(4);
    }
    public void GemsOnClick() {
        inventoryGet.AddGems(3);
    }
}
