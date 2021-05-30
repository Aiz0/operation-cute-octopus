using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundFx;
    private AudioSource audioSource;
    private AudioClip[] inkSounds;
    private AudioClip[] destroySounds;
    private AudioClip[] scoreSound;
    private AudioClip[] starSounds;
    private AudioClip[] rocketEndSounds;
    private AudioClip[] buttonSounds;
    private int randomNumber;

    void Start()
    {
        soundFx = this;
        audioSource = GetComponent<AudioSource>();
        inkSounds = Resources.LoadAll<AudioClip>("InkSounds");
        destroySounds = Resources.LoadAll<AudioClip>("DestroySounds");
        scoreSound = Resources.LoadAll<AudioClip>("ScoreSound");
        starSounds = Resources.LoadAll<AudioClip>("StarSounds");
        rocketEndSounds = Resources.LoadAll<AudioClip>("RocketEndSounds");
        buttonSounds = Resources.LoadAll<AudioClip>("ButtonSounds");
    }

    public void PlayInkSound()
    {
        randomNumber = Random.Range(0, 4);
        audioSource.PlayOneShot(inkSounds[randomNumber]);
    }


    public void PlayDestroySound()
    {
        randomNumber = Random.Range(0, 2);
        audioSource.PlayOneShot(destroySounds[randomNumber]);
    }

    public void PlayHighScoreSound()
    {
        randomNumber = Random.Range(0, 1);
        audioSource.PlayOneShot(scoreSound[randomNumber]);
    }
    public void PlayStarSound()
    {
        randomNumber = Random.Range(0, 1); //bara ett Star Sound, men kodat för att kunna lägga till fler
        audioSource.PlayOneShot(starSounds[randomNumber]);
    }

    public void PlayRocketEndSound()
    {
        randomNumber = Random.Range(0, 1); //bara ett Rocket End Sound, men kodat för att kunna lägga till fler
        audioSource.PlayOneShot(rocketEndSounds[randomNumber]);
    }

    public void PlayButtonSound()
    {
        int index = Random.Range(0, buttonSounds.Length);
        audioSource.PlayOneShot(buttonSounds[index]);
    }
}
