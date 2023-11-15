using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    [Header("Player")]
    private GameObject player = default;

    [Header("Player Health Parameters")]
    private HealthComponent playerHealthComponent = default;
    private int playerHealth = default;
    [SerializeField]private Image[] heartPoints = default;
    [SerializeField]private Sprite fullHeart = default;
    [SerializeField]private Sprite emptyHeart = default;


    [Header("Enemy")]
    //[SerializeField]private GameObject boss = default;

    [Header("Boss Health Parameters")]
    private int bossHealth = default;
    [SerializeField]private TextMeshProUGUI bossHealthText = default;

    [Header("Phase 3 Parameters")]
    private float phase3Timer = default;
    [SerializeField]private TextMeshProUGUI phase3TimerText = default;



    private void Start()
    {
        player = GameObject.Find("Player");
        playerHealthComponent = player.GetComponent<HealthComponent>();
    }

    private void Update()
    {
        PlayerHealthUpdate();
        BossHealthUpdate();
        if (Boss3PhaseManager.instance.phase3) TimerUpdate();
        else phase3TimerText.gameObject.SetActive(false);
    }

    private void PlayerHealthUpdate() {
        playerHealth = playerHealthComponent.currentHealth;

        for (int i = 0; i < heartPoints.Length; i++)
        {
            if (i < playerHealth)
            {
                heartPoints[i].sprite = fullHeart;
            }
            else
            {
                heartPoints[i].sprite = emptyHeart;
            }
        
        }
    }

    private void BossHealthUpdate() {
        bossHealth = Boss3PhaseManager.instance.bossTotalHealth;
        bossHealthText.SetText("Boss Health: " + bossHealth);
    }

    private void TimerUpdate() {
        phase3TimerText.gameObject.SetActive(true);
        phase3Timer = Boss3PhaseManager.instance.phase3ExitTimer;
        phase3TimerText.SetText(phase3Timer.ToString("F0"));
    }
}
