using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public int money;
    public TMP_Text moneyBankAccount;
    public int startingMoney = 0;
    void Start() {
        addMoney(startingMoney);
        refreshMoney(money);
    }
    
    void Update() {

    }

    public void refreshMoney(int refreshMoney) {
        moneyBankAccount.text = money.ToString();
    }

    public void addMoney(int addToMoney) {
        money += addToMoney;
    }

    public void subtractMoney(int subtractToMoney) {
        if(money - subtractToMoney < 0) {
            Debug.Log("Nie wystarczająco pieniążków");
        } else {
            money -= subtractToMoney;
        }
    } 
}
