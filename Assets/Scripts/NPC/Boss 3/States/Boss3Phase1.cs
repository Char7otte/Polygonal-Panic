using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Phase1 : Boss3BaseState
{
    [SerializeField]private float fireRate = default;
    [SerializeField]private Transform[] bulletSpawnPoints = default;
    float timer;
    [SerializeField]private GameObject bulletGroup = default;
    [SerializeField]private GameObject bulletPrefab = default;

    public override void EnterState(Boss3StateManager phase) {
        Debug.Log("Phase 1 started.");
        timer = fireRate;
    }

    public override void UpdateState(Boss3StateManager phase) {
        timer -= Time.deltaTime;
        timer = Mathf.Max(timer, 0);

        if (timer == 0) {
            _MonoBehaviour.StartCoroutine(Shoot());
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
        MonoBehaviour.Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity, bulletGroup.transform);
    }
}
