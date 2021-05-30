using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    //public AudioMixer audioMixer;

    //public void SetVolume(float volume)
    //{
    //    audioMixer.SetFloat("volume", volume);
    //}

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string EffectPref = "EffectPref";

    private int firstPlayInt;

    public Slider backgroundSlider;
    public Slider effectSlider;

    private float backgroundFloat;
    private float effectFloat;

    [SerializeField]
    private GameObject objectMusic;
    [SerializeField]
    private GameObject effectSoundObject;
    [SerializeField ]
    private AudioSource backgroundAudio;
    [SerializeField]
    private AudioSource[] effectAudio;

    private void Start()
    {
        objectMusic = GameObject.FindWithTag("GameMusic");
        backgroundAudio = objectMusic.GetComponent<AudioSource>();

        //effectSoundObject = GameObject.FindWithTag("EffectSound");
        //effectAudio = effectSoundObject.GetComponent<AudioSource[]>();

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backgroundFloat = 1f;
            effectFloat = 1f;
            backgroundSlider.value = backgroundFloat;
            effectSlider.value = effectFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(EffectPref, effectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);

        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            effectFloat = PlayerPrefs.GetFloat(EffectPref);
            backgroundSlider.value = backgroundFloat;
            effectSlider.value = effectFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(EffectPref, effectSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
        for (int i = 0; i < effectAudio.Length; i++)
        {
            effectAudio[i].volume = effectSlider.value;
        }

    }
}
