using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonMoney : MonoBehaviour
{
    private Inventory inventoryGet => GameManager.Instance.Inventory;

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
}
