using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] patterns;

    [SerializeField]
    private float startInterval;
    private float currentInterval;
    public float decreaseIntervalWith;
    [SerializeField]
    private float minInterval;

    private float timer;
    void Start() {
        StartCoroutine(SpawnLoop());
        currentInterval = startInterval;
    }

    private IEnumerator SpawnLoop() {
        while(GameController.instance.IsRunning()) {
                yield return new WaitForSeconds(currentInterval);
                GameObject pattern = GetRandomPattern();
                SpawnObstacles(pattern);
            if (currentInterval <= startInterval && currentInterval > minInterval) currentInterval -= decreaseIntervalWith; 
        }
    }

    private GameObject GetRandomPattern() {
        int rand = Random.Range(0, patterns.Length);
        return patterns[rand];
    }

    private void SpawnObstacles(GameObject pattern) {
        Instantiate(pattern, transform.position, Quaternion.identity);
    }
}
