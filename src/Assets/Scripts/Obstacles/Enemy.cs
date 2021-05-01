using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    public float speedForward;
    public float speedSideways;

    public float minRight;
    public float maxLeft;

    [SerializeField]
    private GameObject effect;

    private void Start()
    {
        int rand = Random.Range(-1, 1);
        speedSideways *= rand;
        if (rand == 0) speedForward *= 2;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speedForward * Time.deltaTime);
        transform.Translate(Vector2.left * speedSideways * Time.deltaTime);
        if(transform.position.x < maxLeft) speedSideways = speedSideways * -1;
        else if (transform.position.x > minRight) speedSideways = speedSideways * -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Instantiate(effect, transform.position, Quaternion.identity);
            GameController.instance.DecrementHealth(damage);
            //Destroy(gameObject);
        }
    }
}
