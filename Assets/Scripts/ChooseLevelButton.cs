using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevelButton : MonoBehaviour
{
    public void FirstLevelChoose()
    {
        SceneManager.LoadScene("Level1");
    }
}
