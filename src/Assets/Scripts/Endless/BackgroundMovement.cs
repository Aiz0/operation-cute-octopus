using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    public float parallaxAmount; // anges i inspector, vilken hastighetskoeffecient för varje lagers parallaxeffekt
    float scrollingSpeed = 2f;  // hastighetsvariabel för alla bakgrunder gemensamt
    Vector2 startingPosition;

    void Start()
    {
        startingPosition = transform.position; // läser av bakgrundgrafikens startposition så den kan relateras till när bakgrunden loopar

    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollingSpeed * parallaxAmount, 20); //sista värdet är offset för hur bakgrunden loopas, kolla att det stämmer med bakgrundens längd i Unity
        transform.position = startingPosition + Vector2.down * newPosition;
    }
}


