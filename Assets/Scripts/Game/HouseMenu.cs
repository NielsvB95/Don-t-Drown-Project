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

    public int HouseLevel;

    public GameObject activeMenu;
    public GameObject popUp;

    private int Index;

    Dictionary<int, HouseModel> UpgradeRequirements;

    void Start()
    {
        HouseLevel = 1;
        MakeHousePlans();
        House.gameObject.GetComponent<SpriteRenderer>().sprite = House_1;
        SetHouse();        
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


    public void SetHouse()
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
        if (Inventory.Stick >= UpgradeRequirements[HouseLevel].Stick && Inventory.Straw >= UpgradeRequirements[HouseLevel].Straw &&
            Inventory.Clay >= UpgradeRequirements[HouseLevel].Clay && Inventory.Wood >= UpgradeRequirements[HouseLevel].Wood &&
            Inventory.Iron >= UpgradeRequirements[HouseLevel].Iron && Inventory.Pebble >= UpgradeRequirements[HouseLevel].Pebble &&
            Inventory.Stone >= UpgradeRequirements[HouseLevel].Stone)
        {
            Inventory.Stick -= UpgradeRequirements[HouseLevel].Stick;
            Inventory.Straw -= UpgradeRequirements[HouseLevel].Straw;
            Inventory.Stone -= UpgradeRequirements[HouseLevel].Stone;
            Inventory.Clay -= UpgradeRequirements[HouseLevel].Clay;
            Inventory.Wood -= UpgradeRequirements[HouseLevel].Wood;
            Inventory.Iron -= UpgradeRequirements[HouseLevel].Iron;
            Inventory.Pebble -= UpgradeRequirements[HouseLevel].Pebble;

            House.gameObject.GetComponent<SpriteRenderer>().sprite = UpgradeHouse.gameObject.GetComponent<Image>().sprite;
            HouseLevel += 1;
        }
        else
        {
            popUp.SetActive(true);
        }
        SetHouse();
    }

    public void MakeHousePlans()
    {
        UpgradeRequirements = new Dictionary<int, HouseModel>();
        UpgradeRequirements.Add(1, HouseModel.houseModel_1);
        UpgradeRequirements.Add(2, HouseModel.houseModel_2);
        UpgradeRequirements.Add(3, HouseModel.houseModel_3);
        UpgradeRequirements.Add(4, HouseModel.houseModel_4);
        UpgradeRequirements.Add(5, HouseModel.houseModel_5);
        UpgradeRequirements.Add(6, HouseModel.houseModel_6);
        UpgradeRequirements.Add(7, HouseModel.houseModel_7);
    }

    public void ClosePopup()
    {
        popUp.SetActive(false);
    }
}
