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
        if (other.CompareTag("Player")){
            if(effect != null){
                Instantiate(effect, transform.position, Quaternion.identity);
            }
            GameController.instance.DecrementHealth(damage);
            Destroy(gameObject);
        }
    }
}
