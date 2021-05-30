using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerup : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUps;
    private void OnDestroy()
    {
        Instantiate(GetRandomPowerUp(), transform.position, Quaternion.identity);
    }

    private GameObject GetRandomPowerUp()
    {
        int random = Random.Range(0, powerUps.Length);
        return powerUps[random];
    }
}
