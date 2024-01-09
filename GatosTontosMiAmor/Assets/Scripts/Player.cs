using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    public Inventory inventory { get; private set; }
    public Image potionCooldownSprite;

    // stats
    private int _moveSpeed;
    private int _attackSpeed;
    private int _attackDamage;
    private int _health;


    private void Awake()
    {
        GameManager.Instance.player = this;
        inventory = new Inventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            UseHealthPotion();
        }

        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    private void UseHealthPotion()
    {
        if (inventory.currentHealthPotionCooldownSeconds > 0) return;
        inventory.UseHealthPotion();
        StartCoroutine(HealthPotionCooldown());
    }

    private IEnumerator HealthPotionCooldown()
    {
        float cooldown = inventory.healthPotionCooldownSeconds;
        float decreceTimeBy = 0.5f;
        while (cooldown > 0)
        {
            inventory.currentHealthPotionCooldownSeconds -= decreceTimeBy;
            potionCooldownSprite.fillAmount =
                inventory.currentHealthPotionCooldownSeconds / inventory.healthPotionCooldownSeconds;
            cooldown -= 0.5f;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Attack()
    {
        Debug.Log("Player wants to attack");
        // TODO: attack
        
    }
}