﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Shooting : MonoBehaviour
{
    [SerializeField]private Transform[] bulletSpawnPositions = default;
    float timer;
    ObjectPoolComponent objectPoolComponent = default;

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
                Phase1Update();
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

    #region Instantiate Bullet Code
    private void InstantiateBullet(Transform bulletSpawnPosition) {
        GameObject bullet = objectPoolComponent.GetPooledObject(); 
        if (bullet != null) {
            bullet.transform.position = bulletSpawnPosition.position;
            bullet.transform.rotation = bulletSpawnPosition.rotation;
            bullet.SetActive(true);
        }
    }
    #endregion

    #region Phase 1 Code
    private void Phase1Enter() {
        Debug.Log("Phase 1 entered.");
        timer = phase1FireRate;
    }
    
    private void Phase1Update() {
        StartCoroutine(Phase1Shooting());
        timer = phase1FireRate * 2;
    }

    IEnumerator Phase1Shooting() { 
        if (bulletSpawnPositions[0]) InstantiateBullet(bulletSpawnPositions[0]);
        yield return new WaitForSeconds(phase1FireRate);

        if (bulletSpawnPositions[1]) InstantiateBullet(bulletSpawnPositions[1]);
        yield return new WaitForSeconds(phase1FireRate);
    }
    #endregion

    #region Phase 2 Code
    private void Phase2Enter() {
        Debug.Log("Phase 2 entered.");
    }

    private void Phase2Update() {

    }
    #endregion
}