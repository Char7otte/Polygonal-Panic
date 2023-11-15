using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void GoToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ToggleActiveObject(GameObject targetObject) {
        targetObject.SetActive(!targetObject.activeSelf);
    }
}
