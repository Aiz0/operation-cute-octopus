using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject baseObstacle;
    public GameObject[] otherObstacles;

    public int riskToSpawnOther = 10;

    void Awake()
    {
        int rand = Random.Range(0, 100);
        if(rand < riskToSpawnOther)
        {
            int random = Random.Range(0, otherObstacles.Length);
            Instantiate(otherObstacles[random], transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(baseObstacle, transform.position, Quaternion.identity);
        }
    }

    void Start(){
        Destroy(transform.root.gameObject);
    }
}
