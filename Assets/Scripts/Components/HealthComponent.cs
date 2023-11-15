using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = default;
    public int currentHealth = default;
    public AudioSource audiosource;
    public AudioClip losesound;

    private void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageValue) {
        currentHealth -= damageValue;
        
        if (currentHealth <= 0) {
            Destroy(this.gameObject);
            audiosource.PlayOneShot(losesound);
        }
    }
}
