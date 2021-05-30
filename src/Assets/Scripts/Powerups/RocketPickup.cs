using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPickup : MonoBehaviour
{
    GameController gameController;

    private void Awake()
    {
        gameController = GameController.instance;
    }

    private void OnTriggerEnter2D()
    {
        gameController.InitiateRocketPowerUp(true);
        Destroy(gameObject);
    }

}
