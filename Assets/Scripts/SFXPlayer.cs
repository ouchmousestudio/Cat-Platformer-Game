using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] AudioClip deathMeow;
    [SerializeField] AudioClip happyMeow;
    [SerializeField] AudioClip deathSqueak;

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    //Singleton
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
        myAudioSource.PlayOneShot(deathMeow, 1f);
    }

    public void HappyMeow()
    {
        myAudioSource.PlayOneShot(happyMeow, 1f);
    }

    public void DeathSqueak()
    {
        myAudioSource.PlayOneShot(deathSqueak, 1f);
    }

    public void SetVolume(float volume)
    {
        myAudioSource.volume = volume;
    }

}
