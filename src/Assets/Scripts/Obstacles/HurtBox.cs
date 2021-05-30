using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private bool rock = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (effect != null)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
            }
            ScreenShakeController.instance.TriggerShake(0.5f);
            if (GameController.instance.playerSprite.enabled == true) // Spelaren tar bara skada om spelarspriten är aktiv, dvs i de fall då spelaren inte har raket-powerup.
            {
                GameController.instance.DecrementHealth(damage);
            }
            SoundManager.soundFx.PlayDestroySound();
            if (!rock) Destroy(gameObject); // Hindra Stenarna att förstöras vid kontakt med spelaren
        }

        if ((other.CompareTag("DrillPowerUp")) || (GameController.instance.playerSprite.enabled == false))
        {
            if (effect != null)
                if (rock)
                {
                    Destroy(gameObject);
                    Instantiate(effect, transform.position, Quaternion.identity);
                    ScreenShakeController.instance.TriggerShake(0.1f);
                    GameController.instance.DecrementDrillPowerUp(1);
                    SoundManager.soundFx.PlayDestroySound();
                }
        }
    }
}

