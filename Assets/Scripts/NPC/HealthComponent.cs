using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]private int maxHealth;
    private int currentHealth;

    private void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageValue) {
        currentHealth -= damageValue;
        
        if (currentHealth <= 0) {
            Destroy(this.gameObject);
        }
    }
}
