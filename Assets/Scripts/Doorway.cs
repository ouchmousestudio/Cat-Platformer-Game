using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
    
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject gameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Chenge to open door tile
        gameObject.SetActive(true);
        StartCoroutine (LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        //int currentScene = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentScene + 1);
        SceneManager.LoadScene("World Map");

    }
}