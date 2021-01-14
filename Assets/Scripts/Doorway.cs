using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorway : MonoBehaviour
    
{
    [SerializeField] private GameObject openDoor;
    [SerializeField] private int levelNumber;

    private float levelLoadDelay = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Chenge to open door tile
        openDoor.SetActive(true);
        
        //Change level number if this is the most recent level
        if (FindObjectOfType<GameSession>().ProgressLevel(levelNumber) < levelNumber)
        {
            FindObjectOfType<GameSession>().ProgressLevel(levelNumber);
        }
        StartCoroutine (LoadWorldMap());
    }

    IEnumerator LoadWorldMap()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        SceneManager.LoadScene("World Map");

    }
}