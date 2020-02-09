using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelIcon : MonoBehaviour
{

    [SerializeField] string sceneName;

    Collider2D myCollider;
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        LevelLoader();
    }

    void LevelLoader()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            return;
        }

    }

}
