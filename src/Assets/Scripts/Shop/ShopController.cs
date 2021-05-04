using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{

    public Text playerStars;
    public Text currentHearts;
    public Text currentInk;

    [SerializeField]
    private GameObject healthText;

    [SerializeField]
    private Text healtButtontext;

    public void Start()
    {
        playerStars.text = PlayerPrefs.GetInt("TotalStars").ToString();
        healthText.SetActive(false);

        UpdateHeartText();
        UpdateInkText();
    }

    public void UpdateHeartText()
    {
        currentHearts.text = PlayerPrefs.GetInt("Health").ToString() + " / 6";
    }

    public void UpdateInkText()
    {
        currentInk.text = PlayerPrefs.GetInt("Ink").ToString() + " / 6";
    }

    public void BuyHealthButton()
    {
        if (PlayerPrefs.GetInt("Health") < 7)
        {
            if (PlayerPrefs.GetInt("TotalStars") >= 1)
            {
                PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 1);
                PlayerPrefs.SetInt("TotalStars", PlayerPrefs.GetInt("TotalStars") - 1);
                playerStars.text = PlayerPrefs.GetInt("TotalStars").ToString();
                UpdateHeartText();
            }
        }
    }

    public void BuyInkButton()
    {
        if(PlayerPrefs.GetInt("Ink") < 7)
        {
            if (PlayerPrefs.GetInt("TotalStars") >= 1)
            {
                PlayerPrefs.SetInt("Ink", PlayerPrefs.GetInt("Ink") + 1);
                PlayerPrefs.SetInt("TotalStars", PlayerPrefs.GetInt("TotalStars") - 1);
                playerStars.text = PlayerPrefs.GetInt("TotalStars").ToString();
                UpdateInkText();
            }
        }
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("Main");
    }
}
