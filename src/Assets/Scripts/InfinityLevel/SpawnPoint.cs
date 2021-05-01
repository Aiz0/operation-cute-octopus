using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject enemy;
    public GameObject star;

    public int probabilityToSpawnStar;
    public int probabilityToSpawnEnemy;

    void Awake()
    {
        int rand = Random.Range(0, 100);
        if(rand < probabilityToSpawnStar) Instantiate(star, transform.position, Quaternion.identity);
        else if(rand > 100 - probabilityToSpawnEnemy) Instantiate(enemy, transform.position, Quaternion.identity);
        else Instantiate(obstacle, transform.position, Quaternion.identity);
    }

    void Start(){
        Destroy(transform.root.gameObject);
    }
}
