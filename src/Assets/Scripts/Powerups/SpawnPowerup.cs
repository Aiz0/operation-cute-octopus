using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerup : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUps;
    [SerializeField]
    [Range(0f, 1f)]
    private float spawnChance;


    private void OnDestroy()
    {
        if (RandomSpawnPowerup()){
            Instantiate(GetRandomPowerUp(), transform.position, Quaternion.identity);
        }
    }

    private bool RandomSpawnPowerup()
    {
        float random = Random.Range(0f,1f);
        return spawnChance >= random;
    }

    private GameObject GetRandomPowerUp()
    {
        int index = Random.Range(0, powerUps.Length);
        return powerUps[index];
    }
}
