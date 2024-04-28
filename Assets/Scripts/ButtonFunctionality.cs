using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionality : MonoBehaviour
{
    [SerializeField] GameObject chooseLevelScreen;
    public void RestartLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);

    }
    public void StartButton()
    {
        chooseLevelScreen.SetActive(true);
    }

    public void CloseChoosePanel()
    {
        chooseLevelScreen.SetActive(false);
    }

    public void ExitFromLevel()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }
}
