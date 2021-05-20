using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text highScoreText;
    public Text totalStarsText;

    void Start()
    {
        UpdateHighScore();
        UpdateTotalStars();
    }

    public void UpdateHighScore()
    {
        if (PlayerPrefs.GetInt("Score") >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        }

        PlayerPrefs.Save();
    }

    public void UpdateTotalStars()
    {
        PlayerPrefs.SetInt("TotalStars", PlayerPrefs.GetInt("TotalStars") + PlayerPrefs.GetInt("Stars"));
        PlayerPrefs.SetInt("Stars", 0);
        totalStarsText.text = PlayerPrefs.GetInt("TotalStars").ToString();
        PlayerPrefs.Save();
    }
}
