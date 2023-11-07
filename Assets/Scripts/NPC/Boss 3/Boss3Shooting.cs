using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Shooting : MonoBehaviour
{
    [SerializeField]private float fireRate = default;
    [SerializeField]private Transform[] bulletSpawnPositions = default;
    float timer;
    ObjectPoolComponent objectPoolComponent = default;

    private void Start() {
        timer = fireRate;
        objectPoolComponent = GetComponent<ObjectPoolComponent>();
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
        if (!bulletSpawnPositions[0]) goto SecondBullet;
        InstantiateBullet(bulletSpawnPositions[0]);
        yield return new WaitForSeconds(fireRate);

        SecondBullet:
        if (!bulletSpawnPositions[1]) yield break;
        InstantiateBullet(bulletSpawnPositions[1]);
        yield return new WaitForSeconds(fireRate);
    }

    private void InstantiateBullet(Transform bulletSpawnPosition) {
        //Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation, bulletGroup.transform);

        GameObject bullet = objectPoolComponent.GetPooledObject(); 
        if (bullet != null) {
            bullet.transform.position = bulletSpawnPosition.position;
            bullet.transform.rotation = bulletSpawnPosition.rotation;
            bullet.SetActive(true);
        }
    }
}