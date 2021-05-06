using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleMoveSimple : MonoBehaviour
{
    private GameController gameController;
    private Rigidbody2D rb2D;

    [SerializeField]
    private float speedMultiplier = 1;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start() {
        gameController = GameController.instance;
    }

    // Update is called once per frame
    void Update() {
        rb2D.velocity = gameController.GetDirection() * gameController.GetSpeed() * speedMultiplier;
    }
}
