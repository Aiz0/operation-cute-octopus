using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string EffectPref = "EffectPref";

    private float backgroundFloat;
    private float effectFloat;

    [SerializeField]
    private AudioSource backgroundAudio;
    [SerializeField]
    private AudioSource effectAudio;

    private void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);

        backgroundAudio.volume = backgroundFloat;

        effectFloat = PlayerPrefs.GetFloat(EffectPref);

        effectAudio.volume = effectFloat;
    }
}
