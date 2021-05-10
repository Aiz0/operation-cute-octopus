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

        if (gC.allowOtherSpawns && allowSpawnRock && (rand <= gC.riskToSpawnRock) && gC.rockObstacles.Length > 0) 
            spawnRock();
        else if (gC.allowOtherSpawns &&  allowSpawnOther && (rand <= gC.riskToSpawnOther) && gC.otherObstacles.Length > 0) 
            spawnOther();
        else 
            Instantiate(gC.baseObstacle, transform.position, Quaternion.identity);
        
    }

    void Start(){
        Destroy(transform.root.gameObject);
    }

    private void spawnRock()
    {
        Quaternion rotation = transform.rotation;
        int random = Random.Range(0, gC.rockObstacles.Length);
        if (transform.position.x > 0) rotation.y = -180;
        Instantiate(gC.rockObstacles[random], transform.position, rotation);
    }

    private void spawnOther()
    {
            int random = Random.Range(0, gC.otherObstacles.Length);
            Instantiate(gC.otherObstacles[random], transform.position, Quaternion.identity);
    }
}
