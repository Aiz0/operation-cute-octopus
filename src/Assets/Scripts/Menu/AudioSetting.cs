using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string EffectPref = "EffectPref";

    private int firstPlayInt;

    private float backgroundFloat;
    private float effectFloat;

    [SerializeField]
    private AudioSource backgroundAudio;
    [SerializeField]
    private AudioSource[] effectAudio;

    private void Awake()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            backgroundFloat = 1f;
            effectFloat = 1f;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(EffectPref, effectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        } 
        else
        { 
            ContinueSettings(); 
        }

    }

    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);

        backgroundAudio.volume = backgroundFloat;

        effectFloat = PlayerPrefs.GetFloat(EffectPref);

        for (int i = 0; i < effectAudio.Length; i++)
        {
            effectAudio[i].volume = effectFloat;
        }
    }
}
