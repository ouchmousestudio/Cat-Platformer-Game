using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Animator myAnimator;
    [SerializeField] ParticleSystem coinSparkle;
    [SerializeField] GameObject catCoinSprite;
    private void Start()
    {
        myAnimator = GetComponent<Animator>();

        float startTime = Random.Range(0f, 1f);
        myAnimator.Play("Coin", 0, startTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Add Sparkle particle effect on pickup.
        catCoinSprite.SetActive(false);

        Destroy(gameObject, 0.3f);
        coinSparkle.Play();
        FindObjectOfType<GameSession>().AddToScore();
        FindObjectOfType<SFXPlayer>().HappyMeow();
    }
}
