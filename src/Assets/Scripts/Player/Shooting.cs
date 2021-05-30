using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    private GameController gameController;
    private Camera cameraMain;
    private Vector2 screenPosition;

    private void Start() {
        gameController = GameController.instance;
        cameraMain = Camera.main;
    }

    private void OnFire(){
        Vector2 position = Input.mousePosition;
        if(gameController.IsRunning())
        {
            Fire(position);
        }
    }

    private void Fire(Vector2 screenPosition) {
        if (gameController.DecrementInk(1)) {
            FireProjectile(screenPosition);
        }
    }

    private void FireProjectile(Vector2 position) {
        GameObject projectileInstance = Instantiate(
                projectile,
                transform.position,
                Quaternion.Euler(0, 0, GetFireAngle(position))
             );
        SoundManager.soundFx.PlayInkSound();
    }

    private float GetFireAngle(Vector2 position) {
        Vector2 direction = position - (Vector2) cameraMain.WorldToScreenPoint(transform.position);
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}
