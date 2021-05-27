using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject shopMenu1;
    public GameObject shopMenu2;

    private void Start()
    {
        shopMenu1.SetActive(true);
        shopMenu2.SetActive(false);
    }
    public void SwitchCameraDown()
    {
        shopMenu1.SetActive(false);
        shopMenu2.SetActive(true);
    }

    public void SwitchCameraUp()
    {
        shopMenu1.SetActive(true);
        shopMenu2.SetActive(false);
    }
}
