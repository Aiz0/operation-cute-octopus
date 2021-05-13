using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class LoadScene : MonoBehaviour
{
    public static LoadScene instance;

    private CanvasGroup canvasGroup;
    [SerializeField]
    private float transitionTime = 1f;

    private void Awake(){
        instance = this;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable(){
        FadeOut();
    }

    public void Load(string sceneName){
        canvasGroup.alpha = 0;
        LeanTween.alphaCanvas(canvasGroup, 1, transitionTime).setOnComplete(() => LoadLevel(sceneName));
    }

    private void FadeOut(){
        canvasGroup.alpha = 1;
        LeanTween.alphaCanvas(canvasGroup, 0, transitionTime);
    }

    private void LoadLevel(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
