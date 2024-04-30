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
    [SerializeField] public AudioSource musicAudio;
    public Text scoreText;
    public static int score;
    private bool _isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseFunction();
        }

        UpdateScoreText();
        ConditionForWin();
    }
    void PauseFunction()
    {
        _isPaused = !_isPaused;
        if (_isPaused && CircleLogic._heroDead == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            musicAudio.volume = 0.15f;
            musicAudio.pitch = 0.5f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            musicAudio.volume = 0.25f;
            musicAudio.pitch = 1f;
        }
    }

    private void ConditionForWin()
    {
        
        string level = SceneManager.GetActiveScene().name;
        if (level == "Level1" && score == 232)
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
