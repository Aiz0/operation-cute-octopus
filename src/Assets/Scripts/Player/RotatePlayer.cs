using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(Rigidbody2D))]
public class RotatePlayer : MonoBehaviour
{

    private float currentRotation;
    private float targetRotation;

    private PlayerData pData;
    private Rigidbody2D rb2D;


    private void Awake() {
        pData = GetComponent<PlayerData>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
        Rotate();
    }

    private void Rotate() {
        targetRotation = pData.MaxRotation * Math.Sign(rb2D.velocity.x) * -1;
        targetRotation *= (Math.Abs(rb2D.velocity.x) / pData.HorizontalMoveSpeed);

        if (currentRotation != targetRotation){
            if (targetRotation != 0){
                currentRotation += pData.RotationAmount * Math.Sign(targetRotation);
                if ((currentRotation > targetRotation && targetRotation > 0) || (currentRotation < targetRotation && targetRotation < 0)){
                    currentRotation = targetRotation;
                }
            } else {
                currentRotation -= pData.RotationAmount * Math.Sign(currentRotation);
                if(Math.Abs(currentRotation) > 0 && Math.Abs(currentRotation) - pData.RotationAmount < 0){
                    currentRotation = targetRotation;
                }
            }
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        }
    }
}
