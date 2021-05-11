using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private PlayerData pData;
    private Rigidbody2D rb2D;
    private Vector2 axis;
    private GameController gameController;

    private void Awake() {
        pData = GetComponent<PlayerData>();
        rb2D = GetComponent<Rigidbody2D>();
        gameController = GameController.instance;

        if (AttitudeSensor.current != null) {
            InputSystem.EnableDevice(AttitudeSensor.current);
        }
    }

    void Update() {
        ClampPosition();
    }

    void FixedUpdate() {
        float direction;
        if(axis.x == 0){
            direction = getAcceleration();
        }else{
            direction = axis.x;
        }
        if(gameController.GameRunning){

            Move(direction);
        }
    }

    public void OnMove(InputValue input){
        axis = input.Get<Vector2>();
    }

    private float getAcceleration(){
        return Input.acceleration.x;
    }

    private void Move(float xDirection) {
        rb2D.AddForce(
            new Vector2(
                xDirection * pData.HorizontalMoveSpeed - rb2D.velocity.x,
                0
            ),
            ForceMode2D.Impulse
        );
    }


    private void ClampPosition(){
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x,-1 * pData.XBounds, pData.XBounds  ),
            transform.position.y
        );
    }
}
