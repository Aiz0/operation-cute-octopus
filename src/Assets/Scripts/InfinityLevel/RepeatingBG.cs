using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{
    public GameController gC;
    private float speed;
    [SerializeField]
    private float endY;
    [SerializeField]
    private float startY;

    private void Start()
    {
        speed = gC.GetSpeed();
    }

    private void Update()
    {
        transform.Translate(Vector2.down * gC.GetSpeed() * Time.deltaTime);

        if(transform.position.y <= endY)
        {
            Vector2 pos = new Vector2(transform.position.x, startY);
            transform.position = pos;
        }
    }
}
