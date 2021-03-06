using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private float speedMultiplier = 1f; //move speed
    [SerializeField]
    private float targetingSpeedMultiplier;
    [SerializeField]
    private float ActivationDistance;

    private GameController gameController;
    private Rigidbody2D rb;
    private GameObject target; //the enemy's target
    private Animator animator;

    private void Awake()
    {
        gameController = GameController.instance;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");

        animator = GetComponent<Animator>();
        animator.SetBool("Puff", false);
    }

    private void FixedUpdate()
    {
        rb.velocity = gameController.GetDirection() * gameController.GetSpeed() * speedMultiplier;
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.transform.position) <= ActivationDistance)
            {
                MoveTowardTarget();
                // Activate puff thingy
                animator.SetBool("Puff", true);
            }
        }
    }

    private void LateUpdate()
    {
        RotateWithVelocity();
    }

    private void MoveTowardTarget()
    {
            Vector2 targetDir = (target.transform.position - transform.position).normalized;
            rb.velocity += targetDir * gameController.GetSpeed() * targetingSpeedMultiplier;
    }

    private void RotateWithVelocity()
    {
        transform.right = rb.velocity.normalized * -1;
    }
}
