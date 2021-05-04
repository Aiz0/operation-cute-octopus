using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveSimple : MonoBehaviour
{
    private Vector2 direction;
    private float speed;
    private GameController gameController;

    [SerializeField]
    private float speedMultiplier = 1;

    void Start() {
        gameController = GameController.instance;

        direction = gameController.GetDirection();
        speed = gameController.GetSpeed();
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(direction * speed * speedMultiplier * Time.deltaTime);
    }
}
