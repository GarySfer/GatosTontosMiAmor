using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    // use fillamount to display health
    // this script will be on healthBarFill object
    [SerializeField] private float lerpSpeed;

    private Health _playerHealthComponent;
    [SerializeField] private Image healthBarFill;


    private void Awake()
    {
        healthBarFill = GetComponent<Image>();
        if (GameManager.Instance.PlayerGameObject == null)
        {
            Debug.Log("player gameobject is null");
        }
        _playerHealthComponent = GameManager.Instance.PlayerGameObject.GetComponent<Health>();
        Debug.Log("bussin: "+_playerHealthComponent);
        _playerHealthComponent.OnHealthChanged += UpdateHealthBar;
    }
    
    private void UpdateHealthBar(int health)
    {
        healthBarFill.fillAmount = (float)health / _playerHealthComponent.maxHealth;
    }
    
}