using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    public int playerLives = 3;

    public int levelNumber = 0;
    public int score = 0;

    public Vector2 lastLocation;

    //Singleton
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            RemoveLife();
        }
        else
        {
            ResetGame();
        }
    }

    public void AddToScore()
    {
        score += 10;
    }

    private void RemoveLife()
    {
        playerLives--;
        FindObjectOfType<UIController>().UpdateLives();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    //Keep Level Progress
    public int ProgressLevel(int levelProgress)
    {
        levelNumber = levelProgress;
        return levelProgress;
    }

}
