using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToShop : MonoBehaviour
{
    public void ButtonToShop()
    {
        SceneManager.LoadScene("Shop");
    }
}
