using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxComponent : MonoBehaviour
{
    [SerializeField]private string colliderObjectTag = default;
    private HealthComponent healthComponent = default;

    private void Start() {
        healthComponent = GetComponent<HealthComponent>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == colliderObjectTag) {
            int damageValue = other.gameObject.GetComponent<BulletScript>().damageValue;
            Destroy(other.gameObject);
            healthComponent.TakeDamage(damageValue);
        }
    }
}
