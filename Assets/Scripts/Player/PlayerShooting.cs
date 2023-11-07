using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]private float gunFireRate = default;
    [SerializeField]private float timer = default;

    [Header("Instantiate settings")]
    [SerializeField]private Transform bulletSpawnPosition = default;
    [SerializeField]private GameObject bulletPrefab = default;
    [SerializeField]private Transform bulletGroup = default;

    private void Start() {
        timer = gunFireRate;
    }

    private void Update() {
        timer -= Time.deltaTime;
        timer = Mathf.Max(timer, 0);

        CheckForInput(gunFireRate);
    }

    private void CheckForInput(float fireRate) {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {

            if (timer == 0) {
                Shoot(fireRate);
            }
        }
    }

    private void Shoot(float fireRate) {
        Instantiate(bulletPrefab, bulletSpawnPosition.position , bulletSpawnPosition.rotation, bulletGroup);
        timer = fireRate;
    }
}
