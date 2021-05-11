using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PolygonCollider2D[] colliders;
    public int currentColliderIndex = 0;
    [SerializeField]
    private float horizontalMoveSpeed = 1;

    [SerializeField]
    private float rotationSpeed = 10;
    [SerializeField]
    private float maxRotation = 45;

    private Rigidbody2D rb2D;
    private Vector2 axis;

    [SerializeField]
    private float xBounds;

    private float currentRotation;
    private float targetRotation;

    public Animator animator;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
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
        Move(direction);
        Rotate(direction);
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
                xDirection * horizontalMoveSpeed - rb2D.velocity.x,
                0
            ),
            ForceMode2D.Impulse
        );
    }

    private void Rotate(float direction) {
        targetRotation = maxRotation * Math.Sign(direction * -1);
        targetRotation *= (Math.Abs(rb2D.velocity.x) / horizontalMoveSpeed);

        if (currentRotation != targetRotation){
            if (targetRotation != 0){
                currentRotation += rotationSpeed * Math.Sign(targetRotation);
                if ((currentRotation > targetRotation && targetRotation > 0) || (currentRotation < targetRotation && targetRotation < 0)){
                    currentRotation = targetRotation;
                }
            } else {
                currentRotation -= rotationSpeed * Math.Sign(currentRotation);
                if(Math.Abs(currentRotation) > 0 && Math.Abs(currentRotation) - rotationSpeed < 0){
                    currentRotation = targetRotation;
                }
            }
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        }
    }

    private void ClampPosition(){
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x,-1 * xBounds, xBounds  ),
            transform.position.y
        );
    }

    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }


}
