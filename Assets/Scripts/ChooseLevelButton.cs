using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevelButton : MonoBehaviour
{
    public Text numberLevel;

    public void LevelChoose()
    {
        int level = System.Convert.ToInt32(numberLevel);
        SceneManager.LoadScene(level);
    }
}
