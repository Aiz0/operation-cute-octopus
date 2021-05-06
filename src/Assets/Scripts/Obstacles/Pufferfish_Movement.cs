using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish_Movement : MonoBehaviour 
{
    [SerializeField]
    private float speedMultiplier = 1.5f;

    [SerializeField]
    private float puffAt = 3;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;

    private GameController gameController;

    private void Start()
    {
        gameController = GameController.instance;
        animator.SetBool("Puff", false);
        animator.speed = gameController.GetSpeed();
    }

    private void Update()
    {
        rb.velocity = gameController.GetDirection() * gameController.GetSpeed() * speedMultiplier;
        if(transform.position.y <= puffAt) animator.SetBool("Puff", true);
    }
}
