using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume = 0.7f;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private float defaultSfxVolume = 0.7f;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        sfxVolumeSlider.value = PlayerPrefsController.GetSFXVolume();
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        var sfxPlayer = FindObjectOfType<SFXPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
            sfxPlayer.SetVolume(sfxVolumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No Music Player found, did you start from Splash Screen?");
        }
    }
    public void SaveAndExit()
    {
        var volume = volumeSlider.value;
        PlayerPrefsController.SetMasterVolume(volume);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        sfxVolumeSlider.value = defaultSfxVolume;
    }
}
