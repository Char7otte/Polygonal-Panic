using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase3EnemySpawnScript : MonoBehaviour
{
    [SerializeField]private float enemySpawnRate = default;
    private bool startedCoroutine = false;
    ObjectPoolComponent objectPoolComponent = default;

    private void Awake() {
        objectPoolComponent = GetComponent<ObjectPoolComponent>();
    }

    private void Update() {
        if (!startedCoroutine) StartCoroutine(SpawnEnemy(enemySpawnRate));
    }

    IEnumerator SpawnEnemy(float spawnRate) {
        startedCoroutine = true;

        InstantiateBullet(this.gameObject.transform);
        yield return new WaitForSeconds(spawnRate);

        startedCoroutine = false;
    }

    private void InstantiateBullet(Transform bulletSpawnPosition) {
        GameObject bullet = objectPoolComponent.GetPooledObject(); 
        if (bullet != null) {
            bullet.transform.position = bulletSpawnPosition.position;
            bullet.transform.rotation = bulletSpawnPosition.rotation;
            bullet.SetActive(true);
        }
    }
}
