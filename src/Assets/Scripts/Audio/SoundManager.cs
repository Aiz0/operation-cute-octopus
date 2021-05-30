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
    private int randomNumber;

    void Start()
    {
        soundFx = this;
        audioSource = GetComponent<AudioSource>();
        inkSounds = Resources.LoadAll<AudioClip>("InkSounds");
        destroySounds = Resources.LoadAll<AudioClip>("DestroySounds");
        scoreSound = Resources.LoadAll<AudioClip>("ScoreSound");
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

}


