using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    private static MenuMusic instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Shop"))
        {
            Destroy(gameObject);
        }
    }
}
