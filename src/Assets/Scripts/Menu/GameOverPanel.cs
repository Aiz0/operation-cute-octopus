using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    private GameController gameController;

    private void Awake()
    {
        gameController = GameController.instance;
        ActivateChildren(false);
    }

    private void OnEnable() {
        gameController.OnGameOver += ShowUI;
    }

    private void OnDisable() {
        gameController.OnGameOver -= ShowUI;
    }

    public void ShowUI(){
        ActivateChildren(true);
    }

    public void ActivateChildren(bool activate){
        foreach (Transform child in transform){
            child.gameObject.SetActive(activate);
        }
    }
}
