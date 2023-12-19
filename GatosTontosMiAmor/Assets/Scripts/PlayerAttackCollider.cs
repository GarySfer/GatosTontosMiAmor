using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAttackCollider : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private float _attackCooldown = 0.5f;
    
    private static readonly int IsAttacking = Animator.StringToHash("isAttacking");
    
    private void Update()
    {
        if (_attackCooldown > 0)
        {
            _attackCooldown -= Time.deltaTime;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && _attackCooldown <= 0)
        {
            animator.SetBool(IsAttacking, true);
            other.GetComponent<Health>().TakeDamage(10);
            _attackCooldown = 0.5f;
        }
    }
    
}
