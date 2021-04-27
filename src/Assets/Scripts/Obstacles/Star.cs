using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    private int value = 1;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            //Instantiate(effect, transform.position, Quaternion.identity);
            GameController.instance.IncrementStars(value);
            Destroy(gameObject);
        }
    }

}
