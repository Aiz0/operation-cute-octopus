using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish_Movement : MonoBehaviour 
{
    [SerializeField]
    private float speedMultiplier = 1.5f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;

    private GameController gameController;

    private void Start()
    {
        gameController = GameController.instance;
    }

    private void Update()
    {
        rb.velocity = gameController.GetDirection() * gameController.GetSpeed() * speedMultiplier;
    }
}
