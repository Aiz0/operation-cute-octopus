using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] patterns;
    private int lastPattern;

    private float spawnTime;
    [SerializeField]
    private float distancBetweenPatterns = 5.0f;
    [SerializeField]
    private float maxSpeed;

    void Start() {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop() {
        while(GameController.instance.IsRunning()) {
            spawnTime = distancBetweenPatterns / GameController.instance.speed;
            yield return new WaitForSeconds(spawnTime);
                GameObject pattern = GetRandomPattern();
                SpawnObstacles(pattern);
            if(maxSpeed > GameController.instance.speed) GameController.instance.increaseSpeed();
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
