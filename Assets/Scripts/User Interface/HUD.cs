using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private GameObject player = default;
    private HealthComponent playerHealthComponent = default;
    private int playerHealth = default;

    [Header("Heart Points")]
    [SerializeField]private Image[] heartPoints = default;
    [SerializeField]private Sprite fullHeart;
    [SerializeField]private Sprite emptyHeart;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerHealthComponent = player.GetComponent<HealthComponent>();
    }

    private void Update()
    {
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
}
