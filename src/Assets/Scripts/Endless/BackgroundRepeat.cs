using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    [SerializeField]
    private float backgroundLength = 20;

    private Vector2 startingPosition;
    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.y <= backgroundLength * -1){
            transform.position = startingPosition;
        }
    }
}
