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

    [Header("Phase 3")]
    [SerializeField]private float phase3FireRate = default;
    private bool phase3Entered = default;

    [Header("Phase 4")]
    //[SerializeField]private float phase4FireRate = default;
    private bool phase4Entered = default;

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
            else if (Boss3PhaseManager.instance.phase2) {
                if (!phase2Entered) {
                    Phase2Enter();
                    phase2Entered = true;
                }
                Phase2Update();
            }
            else if (Boss3PhaseManager.instance.phase3) {
                if (!phase3Entered) {
                    Phase3Enter();
                    phase3Entered = true;
                }
                if (!isCoroutineRunning) Phase3Update();
            }
            else if (Boss3PhaseManager.instance.phase4) {
                if (!phase4Entered) {
                    Phase4Enter();
                    phase4Entered = true;
                }
                if (!isCoroutineRunning) Phase4Update();
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

        bulletSpawnPositions[2].Rotate(0, 0, 360 * 10 * Time.deltaTime);
        InstantiateBullet(bulletSpawnPositions[2]);

        yield return new WaitForSeconds(fireRate);
        isCoroutineRunning = false;
    }
    #endregion

    #region Phase 3 Code
    private void Phase3Enter() {
        Debug.Log("Phase 3 entered.");
    }

    private void Phase3Update() {
        StartCoroutine(Phase3Shooting(bulletSpawnPositions, phase3FireRate));
    }

    IEnumerator Phase3Shooting(Transform[] spawnPoints, float fireRate) {
        isCoroutineRunning = true;

        InstantiateBullet(spawnPoints[0]);
        yield return new WaitForSeconds(fireRate);
        InstantiateBullet(spawnPoints[1]);
        yield return new WaitForSeconds(fireRate);
        InstantiateBullet(spawnPoints[2]);
        yield return new WaitForSeconds(fireRate);

        isCoroutineRunning = false;
    }
    #endregion

    #region Phase 4 Code
    private void Phase4Enter() {
        Debug.Log("Phase 4 entered.");
    }

    private void Phase4Update() {

    }
    #endregion
}