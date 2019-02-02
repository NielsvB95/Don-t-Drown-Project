using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseMenu : MonoBehaviour
{
    public Sprite House_1;
    public Sprite House_2;
    public Sprite House_3;
    public Sprite House_4;
    public Sprite House_5;
    public Sprite House_6;
    public Sprite House_7;
    public Sprite House_8;

    private Sprite CurrentSprite;

    public GameObject House;

    public Image CurrentHouse;
    public Image UpgradeHouse;
    public GameObject UpgradeButton;

    public static bool GameIsPaused = true;
    public static bool HouseMenuCheck = false;

    public GameObject activeMenu;

    private int Index;


    void Start()
    {
        House.gameObject.GetComponent<SpriteRenderer>().sprite = House_1;
        SetHouses();
    }

    void FixedUpdate()
    {
        if (HouseMenuCheck)
        {
            if (GameIsPaused)
            {
                PauseInventory();
            }
            else
            {
                Resume();
                HouseMenuCheck = false;
                GameIsPaused = true;
            }
        }
    }

    public void Resume()
    {
        activeMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseInventory()
    {
        activeMenu.SetActive(true);
        Time.timeScale = 0f;
    }


    public void SetHouses()
    {
        Sprite[] Houses = { House_1, House_2, House_3, House_4, House_5, House_6, House_7, House_8 };
        CurrentSprite = House.gameObject.GetComponent<SpriteRenderer>().sprite;
        CurrentHouse.gameObject.GetComponent<Image>().sprite = CurrentSprite;
        
        if (CurrentSprite == House_8)
        {
            Destroy(UpgradeHouse);
            UpgradeButton.SetActive(false);
        }
        else
        {
            Index = Array.IndexOf(Houses, CurrentSprite);
            UpgradeHouse.gameObject.GetComponent<Image>().sprite = Houses[Index + 1];
        }       
    }

    public void changeHouse()
    {
        House.gameObject.GetComponent<SpriteRenderer>().sprite = UpgradeHouse.gameObject.GetComponent<Image>().sprite;
        SetHouses();
    }
}
