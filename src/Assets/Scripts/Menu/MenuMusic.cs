using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    static bool AudioBegin = false;
    void Awake()
    {
        if (!AudioBegin)
        {
            gameObject.GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
    void Update ()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("main"))
        {
            Destroy(this.gameObject);
        }
    }
}
