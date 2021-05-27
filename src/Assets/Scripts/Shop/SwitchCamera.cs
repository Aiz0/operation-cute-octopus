using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject camera1;
    public GameObject canvas1;
    public GameObject camera2;
    public GameObject canvas2;

    private void Start()
    {
        camera1.SetActive(true);
        canvas1.SetActive(true);
        camera2.SetActive(false);
        canvas2.SetActive(false);
    }
    public void SwitchCameraDown()
    {
        camera1.SetActive(false);
        canvas1.SetActive(false);
        camera2.SetActive(true);
        canvas2.SetActive(true);
    }

    public void SwitchCameraUp()
    {
        camera1.SetActive(true);
        canvas1.SetActive(true);
        camera2.SetActive(false);
        canvas2.SetActive(false);
    }
}
