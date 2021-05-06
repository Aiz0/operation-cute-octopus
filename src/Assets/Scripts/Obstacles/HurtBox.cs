using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private GameObject effect; 

    private void OnTriggerEnter2D(Collider2D other){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Animator animator = player.GetComponent<Animator>();
        if (other.CompareTag("Player")) {           
            if (effect != null){
                Instantiate(effect, transform.position, Quaternion.identity);
            }            
            animator.SetBool("Dead", true);
            GameController.instance.DecrementHealth(damage);
            Destroy(gameObject, 1);
        }
    }
}
