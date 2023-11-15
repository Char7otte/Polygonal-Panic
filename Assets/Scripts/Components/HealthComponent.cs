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
    [SerializeField]private bool godMode = true;

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
            Destroy(this.gameObject);
        }
    }

    private SpriteRenderer CheckForSpriteRenderer() {
        SpriteRenderer _spriteRenderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        if (_spriteRenderer != null)
        {
            Debug.Log("Child with SpriteRenderer found: " + _spriteRenderer.gameObject.name);
            return _spriteRenderer;
        }
        else
        {
            Debug.Log("No child with SpriteRenderer found.");
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
