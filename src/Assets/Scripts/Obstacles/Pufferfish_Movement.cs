using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish_Movement : MonoBehaviour 
{
    private float speed;
    private Vector2 direction;
    [SerializeField]
    private float speedMultiplier = 1.5f;

    [SerializeField]
    private float puffAt = 3;

    [SerializeField]
    private Animator animator;

    private GameController gameController;

    private void Start()
    {
        animator.SetBool("Puff", false);
        gameController = GameController.instance;
        direction = gameController.GetDirection();
        speed = gameController.GetSpeed();
    }

    private void Update()
    {
        transform.Translate(direction * speed * speedMultiplier * Time.deltaTime);
        if(transform.position.y <= puffAt) animator.SetBool("Puff", true);
    }
}
