using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    private Inventory inventoryGet => GameManager.Instance.inventory;

    void OnEnable()
    {
        inventoryGet.OnGemsChange += refreshGems;
        inventoryGet.OnMoneyChange += refreshMoney;
    }

    void OnDisable()
    {
        inventoryGet.OnGemsChange -= refreshGems;
        inventoryGet.OnMoneyChange -= refreshMoney;
    }

    public TMP_Text moneyBankAccount;
    public TMP_Text gemsBankAccount;

    void Start()
    {
        refreshMoney(inventoryGet.GetCoins());
        refreshGems(inventoryGet.GetGems());
    }

    void Update()
    {
    }

    public void refreshMoney(int refreshMoney)
    {
        moneyBankAccount.text = refreshMoney.ToString();
    }
    public void refreshGems(float refreshGems)
    {
        gemsBankAccount.text = refreshGems.ToString();
    }
}