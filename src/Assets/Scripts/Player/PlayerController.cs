using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public PolygonCollider2D[] colliders;
    public int currentColliderIndex = 0;
    [SerializeField]
    private float horizontalMoveSpeed = 1;
    [SerializeField]
    private float verticalMoveSpeed = 1;

    private Rigidbody2D rb2D;
    private Vector2 axis;
    private Camera cameraMain;

    private float xBounds;
    private float yBounds;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        cameraMain = Camera.main;

        if (AttitudeSensor.current != null) {
            InputSystem.EnableDevice(AttitudeSensor.current);
        }
    }

    void Start(){
        xBounds = cameraMain.aspect * cameraMain.orthographicSize;
        yBounds = cameraMain.orthographicSize;

        Debug.Log("xBounds: " + xBounds);
        Debug.Log("yBounds: " + yBounds);
    }
    void Update() {
        ClampPosition();
    }

    void FixedUpdate() {
        if(axis.x == 0){
            Move(getAcceleration());
        }else{
            Move(axis.x);
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
                xDirection * horizontalMoveSpeed - rb2D.velocity.x,
                0
            ),
            ForceMode2D.Impulse
        );
    }

    private void ClampPosition(){
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x,-1 * xBounds, xBounds  ),
            Mathf.Clamp(transform.position.y, -1 * yBounds, yBounds)
        );
    }

    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
}
