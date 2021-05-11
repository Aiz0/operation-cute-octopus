using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerDie : MonoBehaviour
{
    private GameController gameController;
    private Animator animator;
    private Rigidbody2D rb;

    private void Awake() {
        gameController = GameController.instance;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        gameController.OnGameOver += Die;
    }

    private void OnDisable() {
        gameController.OnGameOver -= Die;
    }

    public void Die(){
        animator.SetBool("Dead", true);
        Destroy(gameObject,1);
        rb.velocity = new Vector2(0,0);
    }
}
