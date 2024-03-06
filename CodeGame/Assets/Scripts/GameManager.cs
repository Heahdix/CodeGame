using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isInBattle = false;
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public static GameManager instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameWin()
    {
        gameWinUI.SetActive(true);
        Time.timeScale = 0;
    }
}
