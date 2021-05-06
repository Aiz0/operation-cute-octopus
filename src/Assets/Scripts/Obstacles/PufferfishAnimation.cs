using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PufferfishAnimation : MonoBehaviour
{
    [SerializeField]
    private float puffAt = 3;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.SetBool("Puff", false);
    }

    private void Update()
    {
        if(transform.position.y <= puffAt) animator.SetBool("Puff", true);
    }
}
