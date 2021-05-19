using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public static int skin;

    public Text currentHearts;
    public Text currentInk;

    public Text[] totalStarsText;
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
        UpdateTotalStars();
        UpdateHeartText();
        UpdateInkText();
        CheckCurrentSkin();
        UpdateStatsButton();

        PlayerPrefs.SetString("SkinList", PlayerPrefs.GetString("SkinList") + "0");
    }


    //
    // UPDATE TOTAL STARS
    //

    // ?
    public void UpdateTotalStars()
    {
        for(int i = 0; i < totalStarsText.Length; i++)
        {
            totalStarsText[i].text = PlayerPrefs.GetInt("TotalStars").ToString();
        }
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
                    skinText[i].text = "BUY";
                }
                else if(PlayerPrefs.GetInt("TotalStars") < skinCost)
                {
                    skinText[i].text = "X";
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
            UpdateTotalStars();
        }
    }

    //
    // BUY STATS
    //


    //Rengör
    public void UpdateStatsButton()
    {
        for(int i = 0; i < statsButton.Length; i++)
        {
            if(PlayerPrefs.GetInt("Health") >= maxHealth)
            {
                statsButton[0].gameObject.SetActive(false);
            }

            if (PlayerPrefs.GetInt("Ink") >= maxInk)
            {
                statsButton[1].gameObject.SetActive(false);
            }

            else if (PlayerPrefs.GetInt("TotalStars") >= statCost)
            {
                statsText[i].text = "BUY";
            }
            else if(PlayerPrefs.GetInt("TotalStars") < statCost)
            {
                statsText[i].text = "X";
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
            if (PlayerPrefs.GetInt("TotalStars") >= statCost)
            {
                PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 1);
                PlayerPrefs.SetInt("TotalStars", PlayerPrefs.GetInt("TotalStars") - statCost);
                UpdateTotalStars();
                UpdateHeartText();
                UpdateStatsButton();
            }
        }
    }

    public void BuyInkButton()
    {
        if(PlayerPrefs.GetInt("Ink") < maxInk)
        {
            if (PlayerPrefs.GetInt("TotalStars") >= statCost)
            {
                PlayerPrefs.SetInt("Ink", PlayerPrefs.GetInt("Ink") + 1);
                PlayerPrefs.SetInt("TotalStars", PlayerPrefs.GetInt("TotalStars") - statCost);
                UpdateTotalStars();
                UpdateInkText();
                UpdateStatsButton();
            }
        }
    }
}
