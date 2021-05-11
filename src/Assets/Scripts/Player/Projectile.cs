using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;

    [SerializeField]
    private GameObject effect;

    private Rigidbody2D rb;
    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Shootable shootable = hitInfo.GetComponent<Shootable>();
        if (shootable != null) {
            if (effect != null) {
                Instantiate(effect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
