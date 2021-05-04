using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{

    public float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
