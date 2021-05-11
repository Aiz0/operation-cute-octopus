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

    private void Update()
    {

        if (transform.position.y <= endY)
        {
            Vector2 pos = new Vector2(transform.position.x, startY);
            transform.position = pos;
        }
    }
}
