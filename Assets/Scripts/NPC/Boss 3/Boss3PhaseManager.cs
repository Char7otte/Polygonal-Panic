﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3PhaseManager : MonoBehaviour
{
    #region Mini singleton
    public static Boss3PhaseManager instance;

    private void Awake() {
        instance = this;
        Awake_();
    }
    #endregion

    [Header("Phases")]
    public bool phase1 = default;
    public float phase1ExitHealthPercentage = default;
    public bool phase2 = default;
    public float phase2ExitHealthPercentage = default;
    public bool phase3 = default;

    [Header("Boss Parameters")]
    public int bossMaxHealth = default;
    public int bossTotalHealth = default;
    public GameObject[] bossHurtboxes = default;

    private void Awake_() {
        foreach (var hurtbox in bossHurtboxes) {
            bossMaxHealth += hurtbox.GetComponent<HealthComponent>().maxHealth;
        }
        bossTotalHealth = bossMaxHealth;
    }

    private void Update() {  
        CheckWhichPhase();

        if (phase1) {
            bossTotalHealth = GetBossHealth();
        }
        if (phase2) {
            bossTotalHealth = GetBossHealth();
        }
    }

    private void CheckWhichPhase() {
        if (bossTotalHealth > bossMaxHealth * phase1ExitHealthPercentage) {
            phase1 = true;
        }
        else if (bossTotalHealth > bossMaxHealth * phase2ExitHealthPercentage) {
            phase1 = false;
            phase2 = true;
        }
        else if (bossTotalHealth == 0) {
            phase2 = false;
            phase3 = true;
        }
    }

    private int GetBossHealth() {
        var bossHurtbox1 = 0;
        var bossHurtbox2 = 0;
        if (bossHurtboxes[0]) bossHurtbox1 = bossHurtboxes[0].GetComponent<HealthComponent>().currentHealth;
        if (bossHurtboxes[1]) bossHurtbox2 = bossHurtboxes[1].GetComponent<HealthComponent>().currentHealth;
        return (bossHurtbox1 + bossHurtbox2);
    }
}
