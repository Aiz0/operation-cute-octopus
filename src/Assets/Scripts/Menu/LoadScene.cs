using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static LoadScene instance;

    [SerializeField]
    private Animator transition;

    [SerializeField]
    private float transitionTime = 1f;

    private void Awake(){
        instance = this;
    }

    public void load(string sceneName){
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
