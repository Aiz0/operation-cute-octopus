using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private int amountOfSkins = 2;

    private int currentSkin;

    void Awake()
    {
        SetSkin();
    }

    public void SetSkin()
    {
        currentSkin = PlayerPrefs.GetInt("Skins");
        Animator animator = player.GetComponent<Animator>();

        for(int i = 0; i < amountOfSkins; i++)
        {
            if(i == currentSkin)
            {
                print(currentSkin);
                animator.SetInteger("Change", i);
            }
        }
    }
}
