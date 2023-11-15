using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    #region Singleton
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    #endregion

    public static GameObject player = default;
    private bool playerHasDied = false;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion

        player = GameObject.Find("Player");
    }

    private void Update() {
        if (!player.activeSelf && !playerHasDied) {
            StartCoroutine(GameLose());
        }
    }

    IEnumerator GameLose() {
        playerHasDied = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameLoseScene");
    }
}
