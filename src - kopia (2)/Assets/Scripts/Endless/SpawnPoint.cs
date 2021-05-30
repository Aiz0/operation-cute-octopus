using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private GameController gC;
    [SerializeField]
    private bool allowSpawnRock = false;

    void Awake()
    {
        gC = GameController.instance;
        int rand = Random.Range(0, 100);
        if (gC.GetAllowOtherSpawns() && allowSpawnRock && rand > (100 - gC.GetRiskToSpawnRock()) && gC.GetRockObstacles().Length > 0)
            SpawnRock();
        else if (gC.GetAllowOtherSpawns() && rand < gC.GetRiskToSpawnOther() && gC.GetOtherObstacles().Length > 0)
            SpawnOther();
        else
            Instantiate(gC.GetBaseObstacle(), transform.position, Quaternion.identity);
    }
 
    void Start()
    {
        Destroy(transform.root.gameObject);
    }

    private void SpawnRock()
    {
        int randomRock = Random.Range(0, gC.GetRockObstacles().Length);
        Quaternion rotation = transform.rotation;
        if (transform.position.x > 0) rotation.y = -180;
        Instantiate(gC.GetRockObstacles()[randomRock], transform.position, rotation);
    }

    private void SpawnOther()
    {
        int randomOther = Random.Range(0, gC.GetOtherObstacles().Length);
        Instantiate(gC.GetOtherObstacles()[randomOther], transform.position, Quaternion.identity);
    }
}
