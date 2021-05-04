using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    public Text text;

    public void Start()
    {
        print("HEJ");
        if(PlayerPrefs.GetInt("TotalStars") < 1)
        {

            text.text = "INSUFFICIENT";
        }
        else
        {
            text.text = "BUY";
        }
    }
}
