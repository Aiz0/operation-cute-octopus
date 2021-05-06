using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Shootable shootable = hitInfo.GetComponent<Shootable>();
        if (shootable != null) {
            Destroy(gameObject);
<<<<<<< HEAD
        }else if (hitInfo.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
=======
>>>>>>> fe431a852313d32ba5cb010a7c77af8e99643513
        }
    }

}
