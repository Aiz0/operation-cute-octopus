using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text test;


    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScore();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHighScore()
    {
        int score1 = PlayerPrefs.GetInt("HighScore");


        PlayerPrefs.SetInt("Score1", 0);

        int hej = PlayerPrefs.GetInt("Score");
        //test.text = score1.ToString();
        print(hej);

        if (PlayerPrefs.GetInt("Score") >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
            test.text = PlayerPrefs.GetInt("HighScore").ToString();
            print(PlayerPrefs.GetInt("HighScore"));
        }

        PlayerPrefs.Save();

    }
}
