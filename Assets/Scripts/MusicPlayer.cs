using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip deathMeow;
    [SerializeField] AudioClip happyMeow;
    [SerializeField] AudioClip deathSqueak;

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        int musicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (musicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void DeathMeow()
    {
        myAudioSource.PlayOneShot(deathMeow);
    }

    public void HappyMeow()
    {
        myAudioSource.PlayOneShot(happyMeow);
    }

    public void DeathSqueak()
    {
        myAudioSource.PlayOneShot(deathSqueak);
    }

}
