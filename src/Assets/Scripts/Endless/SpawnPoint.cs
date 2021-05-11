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

        if (gC.AllowOtherSpawns && allowSpawnRock && (rand <= gC.RiskToSpawnRock) && gC.RockObstacles.Length > 0)
            spawnRock();
        else if (gC.AllowOtherSpawns &&  allowSpawnOther && (rand <= gC.RiskToSpawnOther) && gC.OtherObstacles.Length > 0)
            spawnOther();
        else
            Instantiate(gC.BaseObstacle, transform.position, Quaternion.identity);

    }

    void Start(){
        Destroy(transform.root.gameObject);
    }

    private void spawnRock()
    {
        Quaternion rotation = transform.rotation;
        int random = Random.Range(0, gC.RockObstacles.Length);
        if (transform.position.x > 0) rotation.y = -180;
        Instantiate(gC.RockObstacles[random], transform.position, rotation);
    }

    private void spawnOther()
    {
            int random = Random.Range(0, gC.OtherObstacles.Length);
            Instantiate(gC.OtherObstacles[random], transform.position, Quaternion.identity);
    }
}
