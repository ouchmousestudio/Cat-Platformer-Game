using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelIcon : MonoBehaviour
{

    [SerializeField] string sceneName;
    [SerializeField] int thisLevel;
    [SerializeField] TextMeshProUGUI levelText;

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
            levelText.text = sceneName;

            if (thisLevel <= FindObjectOfType<GameSession>().levelNumber)
            {
                levelText.text = sceneName;
                levelText.color = new Color32(255, 255, 255, 200);

                //Show Level Text
                if (Input.GetButtonDown("Jump"))
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
            else
            {
                levelText.color = new Color32(255, 255, 255, 50);
            }
        }
        else
        {
            levelText.text = null;
        }

    }


}
