using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{

    public Text playerStars;

    public void Start()
    {
        playerStars.text = PlayerPrefs.GetInt("TotalStars").ToString();
    }

    public void BuyHealthButton()
    {
        if (PlayerPrefs.GetInt("TotalStars") > 1)
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 1);
            PlayerPrefs.SetInt("TotalStars", PlayerPrefs.GetInt("TotalStars") - 1);
            playerStars.text = PlayerPrefs.GetInt("TotalStars").ToString();
        }
    }










    public void StartGameButton()
    {
        SceneManager.LoadScene("Main");
    }
}
