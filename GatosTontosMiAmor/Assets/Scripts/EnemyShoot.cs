using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnPoint;
    [SerializeField] private float arrowSpeed;
    [SerializeField] private float arrowLifetime;
    [SerializeField] private Animator animator;

    private bool _isFacingRight = true;
    private bool _isPlayerInRange;

    private static readonly int IsShooting = Animator.StringToHash("IsShooting");
    private bool isCoroutineRunning;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = true;
            if (!isCoroutineRunning)
            {
                isCoroutineRunning = true;
                Debug.Log("Starting coroutine");
                StartCoroutine(Shoot());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = false;
        }
    }

    private IEnumerator Shoot()
    {
        animator.SetBool(IsShooting, true);
        yield return new WaitForSeconds(0.5f);

        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
        float arrowVelocityX = _isFacingRight ? arrowSpeed : -arrowSpeed;
        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowVelocityX, 0);

        Destroy(arrow, arrowLifetime);
        animator.SetBool(IsShooting, false);
        yield return new WaitForSeconds(1f);
        if (_isPlayerInRange)
        {
            StartCoroutine(Shoot());
        }
        else
        {
            isCoroutineRunning = false;
        }
    }
}