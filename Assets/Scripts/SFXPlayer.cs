using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip deathMeow;
    [SerializeField] private AudioClip happyMeow;
    [SerializeField] private AudioClip damageMeow;
    [SerializeField] private AudioClip deathSqueak;

    [SerializeField] private AudioClip[] sample;

    AudioSource myAudioSource;

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

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void DeathMeow()
    {
        myAudioSource.PlayOneShot(deathMeow, 1f);
    }

    public void HappyMeow()
    {
        myAudioSource.PlayOneShot(happyMeow, 0.2f);
    }

    public void DamageMeow()
    {
        myAudioSource.PlayOneShot(damageMeow, 2f);
    }

    public void DeathSqueak()
    {
        myAudioSource.PlayOneShot(deathSqueak, 1f);
    }

    public void PlaySFX(int sampleNum)
    {
        myAudioSource.PlayOneShot(sample[sampleNum], 1f);
    }

    public void SetVolume(float volume)
    {
        myAudioSource.volume = volume;
    }

}
