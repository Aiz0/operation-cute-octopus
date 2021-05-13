using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public Transform target; //the enemy's target
    public float moveSpeed = 5f; //move speed


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {

        if (Vector2.Distance(transform.position, target.transform.position) < 5)
        {
            Vector3 targetDir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
    }

}
