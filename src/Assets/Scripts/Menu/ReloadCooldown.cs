using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ReloadCooldown : MonoBehaviour
{
    private Image image;
    private GameController gameController;

    private void Awake()
    {
        image = GetComponent<Image>();
        gameController = GameController.instance;
    }

    private void Start(){
        image.fillAmount = 0f;
    }

    private void Update()
    {
        if(gameController.IsReloading){
            image.fillAmount += 1 / gameController.ReloadTime * Time.deltaTime;

            if (image.fillAmount >= 1){
                image.fillAmount = 0f;
            }
        }
    }
}
