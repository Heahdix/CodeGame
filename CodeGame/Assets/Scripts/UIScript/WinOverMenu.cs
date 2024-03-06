using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOverMenu : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("LevelScene");
        Time.timeScale = 1.0f;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
