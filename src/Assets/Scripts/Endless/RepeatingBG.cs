using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{
    public GameController gC;
    [SerializeField]
    private float endY;
    [SerializeField]
    private float startY;
    [SerializeField]
    private float multiplyer = 1;


    private void Update()
    {
        transform.Translate(Vector2.down * gC.GetSpeed() * multiplyer * Time.deltaTime);

        if(transform.position.y <= endY)
        {
            Vector2 pos = new Vector2(transform.position.x, startY);
            transform.position = pos;
        }
    }
}
