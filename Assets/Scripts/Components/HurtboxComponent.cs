using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxComponent : MonoBehaviour
{
    [SerializeField]private string colliderObjectTag = default;
    private HealthComponent healthComponent = default;

    [Header("Invincibility Frames Parameters")]
    [SerializeField]private float invincibilityTime = default;
    private float timerForIFrames = default;

    public AudioSource audiosource;
    public AudioClip hitsound;

    private void Start() {
        healthComponent = GetComponent<HealthComponent>();
    }

    private void Update()
    {
        timerForIFrames -= Time.deltaTime;
        timerForIFrames = Mathf.Max(timerForIFrames, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == colliderObjectTag && timerForIFrames == 0) {
            int damageValue = other.gameObject.GetComponent<BulletComponent>().damageValue;
            other.gameObject.SetActive(false);
            healthComponent.TakeDamage(damageValue);
            audiosource.PlayOneShot(hitsound);

            timerForIFrames = invincibilityTime;
        }
    }
}
