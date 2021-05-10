using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveSimple : MonoBehaviour
{
    private GameController gameController;
    private Rigidbody2D rb;
    [SerializeField]
    private float speedMultiplier = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        gameController = GameController.instance;
    }

    // Update is called once per frame
    void Update() {
        rb.velocity = gameController.GetDirection() * gameController.GetSpeed() * speedMultiplier;
    }
}
