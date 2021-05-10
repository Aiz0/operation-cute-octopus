using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private GameController gC;
    [SerializeField]
    private bool allowSpawnRock = false;
    [SerializeField]
    private bool allowSpawnOther = true;

    void Awake()
    {
        gC = GameController.instance;
        int rand = Random.Range(0, 100);

        if (gC.GetAllowOtherSpawns() && allowSpawnRock && (rand <= gC.GetRiskToSpawnRock()) && gC.GetRockObstacles().Length > 0) 
            spawnRock();
        else if (gC.GetAllowOtherSpawns() &&  allowSpawnOther && (rand <= gC.GetRiskToSpawnOther()) && gC.GetOtherObstacles().Length > 0) 
            spawnOther();
        else 
            Instantiate(gC.GetBaseObstacle(), transform.position, Quaternion.identity);
        
    }

    void Start(){
        Destroy(transform.root.gameObject);
    }

    private void spawnRock()
    {
        Quaternion rotation = transform.rotation;
        int random = Random.Range(0, gC.GetRockObstacles().Length);
        if (transform.position.x > 0) rotation.y = -180;
        Instantiate(gC.GetRockObstacles()[random], transform.position, rotation);
    }

    private void spawnOther()
    {
            int random = Random.Range(0, gC.GetOtherObstacles().Length);
            Instantiate(gC.GetOtherObstacles()[random], transform.position, Quaternion.identity);
    }
}
