using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;
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
    // Start is called before the first frame update
    void Start()
    {
        
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

    private void RemoveLife()
    {
        playerLives--;
        //var currentScene = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
