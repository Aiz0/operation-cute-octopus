using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerDie : MonoBehaviour
{
    private GameController gameController;
    private Animator animator;

    private void Awake() {
        gameController = GameController.instance;
        animator = GetComponent<Animator>();
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
    }
}
