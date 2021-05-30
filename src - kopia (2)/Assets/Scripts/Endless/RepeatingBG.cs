using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{
    public GameController gC;
    private Rigidbody2D rb;
    [SerializeField]
    private float endY;
    [SerializeField]
    private float startY;
    [SerializeField]
    private float multiplier = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = gC.GetDirection() * multiplier * gC.GetSpeed();

        if (transform.position.y <= endY)
        {
            Vector2 pos = new Vector2(transform.position.x, startY);
            transform.position = pos;
        }
    }
}
