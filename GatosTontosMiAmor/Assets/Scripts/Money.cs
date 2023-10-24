using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int Money;

    void Start() {
        // Money = startingMoney;
    }
    
    void Update() {
        
    }

    public void addMoney(int addToMoney) {
        Money += addToMoney;
    }

    public void subtractMoney(int subtractToMoney) {
        if(Money -= subtractToMoney < 0) {
            Debug.Log("Nie wystarczająco pieniążków");
        } else {
            Money -= subtractToMoney;
        }
    } 
}
