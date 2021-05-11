using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] patterns;

    private GameController gameController;
    private int lastPattern;

    void Start() {
        gameController = GameController.instance;
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop() {
        while(gameController.GameRunning) {
            yield return new WaitForSeconds(gameController.GetSpawnInterval());

            GameObject pattern = GetRandomPattern();
            SpawnObstacles(pattern);
        }
    }

    private GameObject GetRandomPattern()
    {
        int rand;
        do {
            rand = Random.Range(0, patterns.Length);
        } while(rand == lastPattern);
        lastPattern = rand;
        return patterns[rand];
    }

    private void SpawnObstacles(GameObject pattern) {
        Instantiate(pattern, transform.position, Quaternion.identity);
    }
}
