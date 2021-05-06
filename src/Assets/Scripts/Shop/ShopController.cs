using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{
    public static int skin;

    public Text playerStars;
    public Text currentHearts;
    public Text currentInk;

    public Button[] skinButton;
    public Text[] skinText;

    public Button[] statsButton;
    public Text[] statsText;

 
    /// 
    /// CHANGE IN UNITY
    /// 
    public int skinCost;
    public int statCost;

    public int maxHealth;
    public int maxInk;

    public void Start()
    {
        playerStars.text = PlayerPrefs.GetInt("TotalStars").ToString();

        UpdateHeartText();
        UpdateInkText();
        CheckCurrentSkin();
        UpdateStatsButton();

        PlayerPrefs.SetString("SkinList", PlayerPrefs.GetString("SkinList") + "0");
    }

    //
    // BUY SKINS
    //

    public void CheckCurrentSkin()
    {
        for(int i = 0; i < skinButton.Length; i++)
        {
            if(i == PlayerPrefs.GetInt("Skins"))
            {
                skinButton[i].gameObject.SetActive(false);
            }
            else
            {
                skinButton[i].gameObject.SetActive(true);
                if (PlayerPrefs.GetString("SkinList").Contains(i.ToString()))
                {
                    skinText[i].text = "CHANGE";
                }
                else if (PlayerPrefs.GetInt("TotalStars") >= skinCost)
                {
                    skinText[i].text = "BUY: " + skinCost + " STARS";
                }
                else
                {
                    skinText[i].text = "INSUFFICIENT";
                }
            }
        }
    }

    public void BuySkin0Button()
    {
            PlayerPrefs.SetInt("Skins", 0);
            CheckCurrentSkin();
    }

    public void BuySkin1Button()
    {
        if (PlayerPrefs.GetString("SkinList").Contains("1"))
        {
            PlayerPrefs.SetInt("Skins", 1);
            CheckCurrentSkin();
        }

        else if(PlayerPrefs.GetInt("TotalStars") >= skinCost)
        {
            PlayerPrefs.SetString("SkinList", PlayerPrefs.GetString("SkinList") + "1");
            PlayerPrefs.SetInt("Skins", 1);
            PlayerPrefs.SetInt("TotalStars", PlayerPrefs.GetInt("TotalStars") - skinCost);
            CheckCurrentSkin();
        }
    }

    //
    // BUY STATS
    //

    public void UpdateStatsButton()
    {
        for(int i = 0; i < statsButton.Length; i++)
        {
            if (PlayerPrefs.GetInt("TotalStars") >= statCost)
            {
                statsText[i].text = "BUY: " + statCost + " stars";
            }
            else
            {
                statsText[i].text = "INSUFFICIENT";
            }
        }
    }

    public void UpdateHeartText()
    {
        currentHearts.text = PlayerPrefs.GetInt("Health").ToString() + " / " + maxHealth;
    }

    public void UpdateInkText()
    {
        currentInk.text = PlayerPrefs.GetInt("Ink").ToString() + " / " + maxInk;
    }


    public void BuyHealthButton()
    {
        if (PlayerPrefs.GetInt("Health") < maxHealth)
        {
            if (PlayerPrefs.GetInt("TotalStars") >= 1)
            {
                PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 1);
                PlayerPrefs.SetInt("TotalStars", PlayerPrefs.GetInt("TotalStars") - statCost);
                playerStars.text = PlayerPrefs.GetInt("TotalStars").ToString();
                UpdateHeartText();
            }
        }
    }

    public void BuyInkButton()
    {
        if(PlayerPrefs.GetInt("Ink") < maxInk)
        {
            if (PlayerPrefs.GetInt("TotalStars") >= 1)
            {
                PlayerPrefs.SetInt("Ink", PlayerPrefs.GetInt("Ink") + 1);
                PlayerPrefs.SetInt("TotalStars", PlayerPrefs.GetInt("TotalStars") - statCost);
                playerStars.text = PlayerPrefs.GetInt("TotalStars").ToString();
                UpdateInkText();
            }
        }
    }

    //
    // 
    //


    public void StartGameButton()
    {
        SceneManager.LoadScene("Main");
    }
}
