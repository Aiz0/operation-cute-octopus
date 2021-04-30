using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text highScoreText;
    public Text totalStarsText;


    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScore();
        UpdateTotalStars();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHighScore()
    {
        if (PlayerPrefs.GetInt("Score") >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
            print(PlayerPrefs.GetInt("HighScore"));
            
        }
        else
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }


        PlayerPrefs.Save();
    }

    public void UpdateTotalStars()
    {
        int newStars = PlayerPrefs.GetInt("Stars");
        int totalStars = PlayerPrefs.GetInt("TotalStars");
        int addStars = newStars + totalStars;
        PlayerPrefs.SetInt("TotalStars",addStars);
        PlayerPrefs.SetInt("Stars", 0);
        totalStarsText.text = PlayerPrefs.GetInt("TotalStars").ToString();
        PlayerPrefs.Save();
    }
}
