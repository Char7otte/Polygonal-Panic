using System.Collections;
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
    public bool phase2 = default;
    public bool phase3 = default;

    [Header("Boss Parameters")]
    public int bossTotalHealth = default;
    public GameObject[] bossHurtboxes = default;

    private void Awake_() {
        phase1 = true;
    }

    private void Start() {
        
    }

    private void Update() {  
        if (phase1) {
            var bossHurtbox1 = 0;
            var bossHurtbox2 = 0;
            if (bossHurtboxes[0]) bossHurtbox1 = bossHurtboxes[0].GetComponent<HealthComponent>().currentHealth;
            if (bossHurtboxes[1]) bossHurtbox2 = bossHurtboxes[1].GetComponent<HealthComponent>().currentHealth;
            bossTotalHealth = bossHurtbox1 + bossHurtbox2;
        }
    }
}
