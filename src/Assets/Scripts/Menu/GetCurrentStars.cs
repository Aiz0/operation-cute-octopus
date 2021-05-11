using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetCurrentStars : MonoBehaviour
{
    private GameController gameController;
    private Text text;

    private void Awake()
    {
        gameController = GameController.instance;
        text = GetComponent<Text>();
    }

    private void OnEnable() {
        gameController.OnStarUpdate += updateText;
    }

    private void OnDisable() {
        gameController.OnStarUpdate -= updateText;
    }

    private void updateText(int value){
        text.text = value.ToString();
    }
}
