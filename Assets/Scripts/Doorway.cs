using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
    
{
    [SerializeField] private GameObject openDoor;
    [SerializeField] private int levelNumber;

    private float levelLoadDelay = 0.3f;
    [SerializeField] private bool isLastLevel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Chenge to open door tile
        openDoor.SetActive(true);
        
        //Change level number if this is the most recent level
        if (FindObjectOfType<GameSession>().ProgressLevel(levelNumber) < levelNumber)
        {
            FindObjectOfType<GameSession>().ProgressLevel(levelNumber);
        }
        if (!isLastLevel)
        {
            StartCoroutine(LoadWorldMap());
        }
        else
        {
            //Load ending scene.
            SceneManager.LoadScene("End");
        }
        
    }

    IEnumerator LoadWorldMap()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        SceneManager.LoadScene("World Map");
    }
}