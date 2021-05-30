using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillPickup : MonoBehaviour
{
    GameController gameController;

    private void Awake()
    {
        gameController = GameController.instance;
    }

    private void OnTriggerEnter2D()
    {
        gameController.InitiateDrillPowerUp(true);
        Destroy(gameObject);
    }

}
