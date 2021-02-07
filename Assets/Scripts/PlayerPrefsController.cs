using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master volume";
    const string SFX_VOLUME_KEY = "sfx volume";
    const string LEVEL_PROGRESS_KEY = "level number";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    public static void SetMasterVolume(float volume)
    { 
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Master volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 0.7f);
    }

    public static void SetSFXVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("SFX volume set to " + volume);
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("SFX volume is out of range");
        }
    }

    public static float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 0.9f);
    }

    public static void SetLevelProgress(int number)
    {
        PlayerPrefs.SetInt(LEVEL_PROGRESS_KEY, number);
    }

    public static int GetLevelProgress()
    {
        return PlayerPrefs.GetInt(LEVEL_PROGRESS_KEY, 0);
    }

    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

}
