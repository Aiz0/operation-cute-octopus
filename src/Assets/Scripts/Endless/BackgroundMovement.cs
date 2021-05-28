using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    public float parallaxAmount; // anges i inspector, vilken hastighetskoeffecient f�r varje lagers parallaxeffekt
    float scrollingSpeed = 2f;  // hastighetsvariabel f�r alla bakgrunder gemensamt
    Vector2 startingPosition;

    void Start()
    {
        startingPosition = transform.position; // l�ser av bakgrundgrafikens startposition s� den kan relateras till n�r bakgrunden loopar

    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollingSpeed * parallaxAmount, 20); //sista v�rdet �r offset f�r hur bakgrunden loopas, kolla att det st�mmer med bakgrundens l�ngd i Unity
        transform.position = startingPosition + Vector2.down * newPosition;
    }
}


