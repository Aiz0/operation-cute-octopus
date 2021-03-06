using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject effect;
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
