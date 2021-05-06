using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] patterns;

    //TODO Move to gameController
    public float distanceBetweenPatterns = 5.0f;
    [SerializeField]
    private float maxSpeed;

    private GameController gameController;
    private int lastPattern;

    void Start() {
        gameController = GameController.instance;
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop() {
        while(gameController.IsRunning()) {
            float spawnInterval = distanceBetweenPatterns / gameController.speed;
            yield return new WaitForSeconds(spawnInterval);

            GameObject pattern = GetRandomPattern();
            SpawnObstacles(pattern);

            if(maxSpeed > gameController.speed) gameController.increaseSpeed();
        }
    }

    private GameObject GetRandomPattern()
    {
        int rand = Random.Range(0, patterns.Length);
        while(rand == lastPattern) rand = Random.Range(0, patterns.Length);
        lastPattern = rand;
        return patterns[rand];
    }

    private void SpawnObstacles(GameObject pattern) {
        Instantiate(pattern, transform.position, Quaternion.identity);
    }
}
