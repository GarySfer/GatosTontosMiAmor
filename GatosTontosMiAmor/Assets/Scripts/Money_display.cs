using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    private Inventory inventoryGet => GameManager.Instance.Inventory;
    public TMP_Text moneyBankAccount;

    void Start()
    {
        refreshMoney(inventoryGet.GetCoins());
    }

    void OnEnable()
    {
        inventoryGet.OnMoneyChange += refreshMoney;
    }

    void OnDisable()
    {
        inventoryGet.OnMoneyChange -= refreshMoney;
    }

    public void refreshMoney(int refreshMoney)
    {
        moneyBankAccount.text = refreshMoney.ToString();
    }
}