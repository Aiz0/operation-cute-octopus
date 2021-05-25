using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PufferfishAnimation : MonoBehaviour
{
    [SerializeField]
    private float puffAt = 3;
    public int angle;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        animator.SetBool("Puff", false);
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void Update()
    {
        if(transform.position.y <= puffAt) animator.SetBool("Puff", true);
    }
}
