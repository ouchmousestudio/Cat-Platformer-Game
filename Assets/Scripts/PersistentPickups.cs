using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentPickups : MonoBehaviour
{

    int startingIndex;

    //Singleton
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<PersistentPickups>().Length;
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
        startingIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex != startingIndex)
        {
            Destroy(gameObject);
        }
    }
}
