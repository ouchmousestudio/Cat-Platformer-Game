using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    
    int playerLives = 3;
    int playerHealth;

    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    [SerializeField] GameObject heart3;
    [SerializeField] TextMeshProUGUI livesText;

    // Start is called before the first frame update
    private void Start()
    { 
        playerHealth = FindObjectOfType<Player>().health;
        UpdateLives();
    }

    public void UpdateLives()
    {
        playerLives = FindObjectOfType<GameSession>().playerLives;
        livesText.text = " " + playerLives.ToString();
    }

    public void UpdateHealth()
    {
        playerHealth = FindObjectOfType<Player>().health;
        UpdateIcons(playerHealth, heart1, heart2, heart3);

    }

    void UpdateIcons(int input, GameObject icon1, GameObject icon2, GameObject icon3)
    {
        switch (playerHealth)
        {
            case 0:
                icon1.SetActive(false);
                icon2.SetActive(false);
                icon3.SetActive(false);
                break;
            case 1:
                icon1.SetActive(true);
                icon2.SetActive(false);
                icon3.SetActive(false);
                break;
            case 2:
                icon1.SetActive(true);
                icon2.SetActive(true);
                icon3.SetActive(false);
                break;
            case 3:
                icon1.SetActive(true);
                icon2.SetActive(true);
                icon3.SetActive(true);
                break;

            default:
                icon1.SetActive(true);
                icon2.SetActive(true);
                icon3.SetActive(true);
                break;
        }


    }



}
