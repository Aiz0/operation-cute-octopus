using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ChangeSkin : MonoBehaviour
{
    [SerializeField]
    private int amountOfSkins = 2;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        SetSkin();
    }

    public void SetSkin()
    {
        int currentSkin = PlayerPrefs.GetInt("Skins");
        if (currentSkin >= amountOfSkins || currentSkin < 0)
        {
            currentSkin = 0;
        }
        animator.SetInteger("Change", currentSkin);
    }
}
