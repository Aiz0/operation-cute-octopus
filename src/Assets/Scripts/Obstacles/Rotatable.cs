using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour
{

    [SerializeField]
    private int maxRotateSpeed;
    [SerializeField]
    private int minRotateSpeed;
    private int rand;

    void Start()
    {
        rand = Random.Range(minRotateSpeed, maxRotateSpeed) * (Random.Range(0,2)*2-1);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rand * Time.deltaTime));
    }
}
