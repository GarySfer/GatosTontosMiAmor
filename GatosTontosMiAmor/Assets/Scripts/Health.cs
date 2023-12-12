using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public event Action<int> OnHealthChanged = delegate { };


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        OnHealthChanged(health);
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        OnHealthChanged(health);
    }

    public void setMaxHealth()
    {
        health = maxHealth;
        OnHealthChanged(health);
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}