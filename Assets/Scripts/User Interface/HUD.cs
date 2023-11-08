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
    [SerializeField]private GameObject boss = default;

    [Header("Boss Health Parameters")]
    private int bossHealth = default;
    [SerializeField]private TextMeshProUGUI bossHealthText = default;



    private void Start()
    {
        player = GameObject.Find("Player");
        playerHealthComponent = player.GetComponent<HealthComponent>();
    }

    private void Update()
    {
        PlayerHealthUpdate();
        BossHealthUpdate();
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
}
