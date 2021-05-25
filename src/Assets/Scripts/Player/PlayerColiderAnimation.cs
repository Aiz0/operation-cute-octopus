using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColiderAnimation : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;

    [SerializeField]
    private Animator animator;

    private void Update()   
    {
        if(animator.GetBool("isDead") == true)
        {
            transform.Rotate(new Vector3(0, 0, 0.65f));
        }
    }
    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
}
