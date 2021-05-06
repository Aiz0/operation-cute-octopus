using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;

    [SerializeField]
    private GameObject effect;

    public string tagToIgnore = "Player";
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)

    { 
        if (effect != null)
        {

            Instantiate(effect, transform.position, Quaternion.identity);

        }

        Destroy(gameObject);
    }
}
