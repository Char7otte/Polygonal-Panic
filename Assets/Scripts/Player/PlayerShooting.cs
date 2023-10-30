using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]private int bulletDamage = default;
    [SerializeField]private float gunFireRate = default;
    [SerializeField]private Transform bulletSpawnPosition = default;
    [SerializeField]private GameObject bulletPrefab = default;

    private void Update() {
        Shoot(bulletDamage, gunFireRate);
    }

    private void Shoot(int damage, float fireRate) {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
            Instantiate(bulletPrefab, bulletSpawnPosition);
        }
    }
}
