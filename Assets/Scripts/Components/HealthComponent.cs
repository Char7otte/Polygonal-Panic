using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = default;
    public int currentHealth = default;
    private SpriteRenderer spriteRenderer = default;
    private bool startedCoroutine = false;

    [Header("Debug")]
    [SerializeField]private bool godMode = false;
    public AudioSource audiosource;
    public AudioClip losesound;

    private void Start() {
        currentHealth = maxHealth;
        spriteRenderer = CheckForSpriteRenderer();
    }

    private void Update() {
        if (godMode) currentHealth = maxHealth;
    }

    public void TakeDamage(int damageValue) {
        currentHealth -= damageValue;
        DamageProbeEffect();
        
        if (currentHealth <= 0) {
            this.gameObject.SetActive(false);
            audiosource.PlayOneShot(losesound);
        }
    }

    private SpriteRenderer CheckForSpriteRenderer() {
        SpriteRenderer _spriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        if (_spriteRenderer != null)
        {
            return _spriteRenderer;
        }
        else
        {
            return null;
        }
    }

    private void DamageProbeEffect() {
        if (spriteRenderer == null) return;
        if (!startedCoroutine) StartCoroutine(DamageStrobeAnimation());
    }

    IEnumerator DamageStrobeAnimation() {
        startedCoroutine = true;

        Color currentColor = spriteRenderer.color;
        currentColor.a = 0;
        spriteRenderer.color = currentColor;

        yield return new WaitForSeconds(0.05f);
        currentColor.a = 255;
        spriteRenderer.color = currentColor;
        startedCoroutine = false;
    }
}
