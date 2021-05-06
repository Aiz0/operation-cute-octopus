using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish_Movement : MonoBehaviour
{
    [SerializeField]
    private float puffAt = 3;

    [SerializeField]
    private Animator animator;

    private void Start()
    {
        animator.SetBool("Puff", false);
    }

    private void Update()
    {
        if(transform.position.y <= puffAt) animator.SetBool("Puff", true);
    }
}
