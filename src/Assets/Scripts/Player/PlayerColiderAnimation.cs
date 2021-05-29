using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColiderAnimation : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;

    [SerializeField]
    private CapsuleCollider2D squidCollider;

    [SerializeField]
    private Animator animator;

    private void FixedUpdate()   
    {
        if(animator.GetBool("isDead") == true)
        {
            transform.Rotate(new Vector3(0, 0, 4f));
        }
    }
    public void SetColliderForSprite(int spriteNum)
    {
        if(animator.GetInteger("Change") == 2)
        {
            squidCollider.enabled = true;
        } 
        else
        {
            squidCollider.enabled = false;
            colliders[currentColliderIndex].enabled = false;
            currentColliderIndex = spriteNum;
            colliders[currentColliderIndex].enabled = true;
        }
        
    }
}
