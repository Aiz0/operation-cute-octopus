using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field: SerializeField]
    public float HorizontalMoveSpeed
    {get; private set;}

    [field: SerializeField]
    public float RotationAmount
    {get; private set;}
    [field: SerializeField]
    public float MaxRotation
    {get; private set;}

    [field: SerializeField]
    public float XBounds
    {get; private set;}

}
