using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    [SerializeField] private Animator animator;
    private static readonly int IsDead = Animator.StringToHash("IsDying");
    private bool _isanimatorNotNull;
    public event Action<int> OnHealthChanged = delegate { };
    private bool _isDead;


    private void Start()
    {
        _isanimatorNotNull = animator != null;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead) return;
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
        Debug.Log(name + " died");
        StartCoroutine(DeathAnimation());
    }
    
    private IEnumerator DeathAnimation()
    {
        if (_isanimatorNotNull && !_isDead)
        {
            animator.SetBool(IsDead, true);
        }
        _isDead = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}