using System.Collections;
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

            //Enable Level counter
            if (thisLevel <= FindObjectOfType<GameSession>().levelNumber)
            {
                //Show Level Text
                levelText.text = sceneName;
                levelText.color = new Color32(255, 255, 255, 200);

                if (Input.GetButtonDown("Jump"))
                {
                    FindObjectOfType<Dissolve>().DissolveOut();
                    //TODO: Recent edit
                    Vector2 playerPos = new Vector2(transform.position.x, transform.position.y + 0.25f);
                    FindObjectOfType<GameSession>().lastLocation = playerPos;
                    StartCoroutine(DissolveToLevel());
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
    IEnumerator DissolveToLevel()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneName);
    }
}
