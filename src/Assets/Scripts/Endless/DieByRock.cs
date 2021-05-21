using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieByRock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock"))
            Destroy(gameObject);
    }
}
