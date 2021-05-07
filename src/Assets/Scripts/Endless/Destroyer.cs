using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    public void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
