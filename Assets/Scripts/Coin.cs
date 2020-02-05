using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        float startTime = Random.Range(0f, 1f);
        myAnimator.Play("Coin", 0, startTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject, 0.1f);
        FindObjectOfType<MusicPlayer>().HappyMeow();
    }
}
