using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Shooting : MonoBehaviour
{
    [SerializeField]private Transform[] bulletSpawnPositions = default;
    float timer;
    ObjectPoolComponent objectPoolComponent = default;

    [Header("Phases")]
    private bool isCoroutineRunning = false;
    private int timesToRepeat = default;

    [Header("Phase 1")] 
    [SerializeField]private float phase1FireRate = default;
    private bool phase1Entered = default;

    [Header("Phase 2")]
    [SerializeField]private float phase2FireRate = default;
    private bool phase2Entered = default;

    private void Start() {
        objectPoolComponent = GetComponent<ObjectPoolComponent>();
    }

    private void Update() {
        timer -= Time.deltaTime;
        timer = Mathf.Max(timer, 0);

        if (timer == 0) {
            if (Boss3PhaseManager.instance.phase1) {
                if (!phase1Entered) {
                    Phase1Enter();
                    phase1Entered = true;
                }
                if (!isCoroutineRunning) Phase1Update();
            }
            if (Boss3PhaseManager.instance.phase2) {
                if (!phase2Entered) {
                    Phase2Enter();
                    phase2Entered = true;
                }
                Phase2Update();
            }
        }
    }

    private void InstantiateBullet(Transform bulletSpawnPosition) {
        GameObject bullet = objectPoolComponent.GetPooledObject(); 
        if (bullet != null) {
            bullet.transform.position = bulletSpawnPosition.position;
            bullet.transform.rotation = bulletSpawnPosition.rotation;
            bullet.SetActive(true);
        }
    }

    #region Phase 1 Code
    private void Phase1Enter() {
        Debug.Log("Phase 1 entered.");
        timer = phase1FireRate;
    }

    private void Phase1Update() {
        timer = phase1FireRate * 2;
        StartCoroutine(Phase1Shooting(phase1FireRate));
    }

    IEnumerator Phase1Shooting(float fireRate) { 
        isCoroutineRunning = true;

        timesToRepeat = 5;
        for (int i = 0; i < timesToRepeat; i++) {
            if (bulletSpawnPositions[0]) InstantiateBullet(bulletSpawnPositions[0]);
            yield return new WaitForSeconds(fireRate);
            if (bulletSpawnPositions[1]) InstantiateBullet(bulletSpawnPositions[1]);
            yield return new WaitForSeconds(fireRate);
        }

        timesToRepeat = 10;
        for (int i = 0; i < timesToRepeat; i++) {
            InstantiateBullet(bulletSpawnPositions[2]);
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(fireRate);
        isCoroutineRunning = false;
    }
    #endregion

    #region Phase 2 Code
    private void Phase2Enter() {
        Debug.Log("Phase 2 entered.");
        timer = phase2FireRate;
    }

    private void Phase2Update() {
        timer = phase2FireRate;
        StartCoroutine(Phase2Shooting(phase2FireRate));
    }

    IEnumerator Phase2Shooting(float fireRate) {
        isCoroutineRunning = true;

        bulletSpawnPositions[2].Rotate(0, 0, 360 * 5 * Time.deltaTime);
        InstantiateBullet(bulletSpawnPositions[2]);

        yield return new WaitForSeconds(fireRate);
        isCoroutineRunning = false;
    }
    #endregion
}