using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GetHighScore : MonoBehaviour
{
    private Text text;

    private void Awake(){
        text = GetComponent<Text>();
    }

    private void Start()
    {
        text.text = PlayerStats.Instance.HighScore.ToString();
    }

}
