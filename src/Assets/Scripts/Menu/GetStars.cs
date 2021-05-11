using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetStars : MonoBehaviour
{
    private Text text;

    private void Awake(){
        text = GetComponent<Text>();
    }

    private void Start()
    {
        text.text = Score.Instance.Stars.ToString();
    }

}
