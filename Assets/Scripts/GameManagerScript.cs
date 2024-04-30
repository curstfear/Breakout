using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject winScreen;
    public Text scoreText;
    public static int score;

    void Update()
    {
        PauseFunction();
        UpdateScoreText();
        ConditionForWin();
    }
    void PauseFunction()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ContinueGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    private void ConditionForWin()
    {
        
        string level = SceneManager.GetActiveScene().name;
        if (level == "Level1" && score == 231)
        {
            Destroy(gameObject);
            winScreen.SetActive(true);
        }
    }
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
