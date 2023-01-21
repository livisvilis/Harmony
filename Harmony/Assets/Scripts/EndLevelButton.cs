using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelButton : MonoBehaviour
{
    private static int _nextLevelIndex = 1;
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Next()
    {
        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
