using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Singleton<PlayerStats>
{

    private int _highScore;
    private int _stars;

    public int HighScore
    {
        get {
            if (_highScore == 0){
                _highScore = PlayerPrefs.GetInt("HighScore", 0);
            }
            return _highScore;
        }
        set {
            if (value > _highScore){
                _highScore = value;
                PlayerPrefs.SetInt("HighScore", _highScore);
                PlayerPrefs.Save();
            }
        }
    }

    public int Stars
    {
        get {
            if (_stars == 0){
                _stars = PlayerPrefs.GetInt("Stars", 0);
            }
            return _stars;
        }
        set {
            _stars = value;
                PlayerPrefs.SetInt("Stars", _stars);
                PlayerPrefs.Save();
        }
    }
}
