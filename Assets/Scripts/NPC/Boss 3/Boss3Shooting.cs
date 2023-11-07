using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Shooting : MonoBehaviour
{
    [SerializeField]private float fireRate = default;
    [SerializeField]private Transform[] bulletSpawnPoints = default;
    float timer;
    [SerializeField]private GameObject bulletGroup = default;
    [SerializeField]private GameObject bulletPrefab = default;

    private void Start() {
        timer = fireRate;
    }

    private void Update() {
        timer -= Time.deltaTime;
        timer = Mathf.Max(timer, 0);

        if (timer == 0) {
            StartCoroutine(Shoot());
            timer = fireRate * 2;
        }
    }

    IEnumerator Shoot() { 
        if (!bulletSpawnPoints[0]) goto SecondBullet;
        InstantiateBullet(bulletSpawnPoints[0]);
        yield return new WaitForSeconds(fireRate);

        SecondBullet:
        if (!bulletSpawnPoints[1]) yield break;
        InstantiateBullet(bulletSpawnPoints[1]);
        yield return new WaitForSeconds(fireRate);
    }

    private void InstantiateBullet(Transform spawnPoint) {
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation, bulletGroup.transform);
    }
}