using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseMenu : MonoBehaviour
{
    public static bool HouseCheck = false;
    public bool HouseBuild = false;

    public Sprite House_1;
    public Sprite House_2;
    public Sprite House_3;
    public Sprite House_4;
    public Sprite House_5;
    public Sprite House_6;
    public Sprite House_7;
    public Sprite House_8;

    public List<Sprite> Sprites;
    public Sprite LastHouse;

    public Sprite Stick;
    public Sprite Clay;
    public Sprite Straw;
    public Sprite Wood;
    public Sprite Stone;
    public Sprite Iron;

    private Sprite CurrentSprite;

    public GameObject House;

    public Image CurrentHouse;
    public Image UpgradeHouse;
    public GameObject UpgradeButton;

    public static bool GameIsPaused = true;
    public static bool HouseMenuCheck = false;

    public int HouseLevel;

    public GameObject activeMenu;
    public GameObject popUp1;
    public GameObject popUp2;

    private int Index;

    Dictionary<int, HouseModel> UpgradeRequirements;

    public Text HouseKost_1;
    public Text HouseKost_2;
    public Text HouseKost_3;
    public Text HouseKost_4;

    public Image Resource_1;
    public Image Resource_2;
    public Image Resource_3;
    public Image Resource_4;

    void Start()
    {
        //HouseImage.SetSprites();
        HouseLevel = 1;
        MakeHousePlans();
        House.gameObject.GetComponent<SpriteRenderer>().sprite = House_1;
        SetHouse();
        ChangeCosts();
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

    public void ChangeCosts()
    {
        if (House.gameObject.GetComponent<SpriteRenderer>().sprite == House_1)
        {
            Resource_3.enabled = false;
            Resource_3.enabled = false;
            Resource_4.enabled = false;
            HouseKost_4.enabled = false;
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stick.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Straw.ToString();
        }
        else if (House.gameObject.GetComponent<SpriteRenderer>().sprite == House_2)
        {
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stick.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Straw.ToString();
        }
        else if (House.gameObject.GetComponent<SpriteRenderer>().sprite == House_3)
        {
            Resource_3.enabled = true;
            HouseKost_3.enabled = true;
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stick.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Straw.ToString();
            HouseKost_3.text = UpgradeRequirements[HouseLevel].Wood.ToString();
        }
        else if (House.gameObject.GetComponent<SpriteRenderer>().sprite == House_4)
        {
            Resource_4.enabled = true;
            HouseKost_4.enabled = true;
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stick.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Straw.ToString();
            HouseKost_3.text = UpgradeRequirements[HouseLevel].Wood.ToString();
            HouseKost_4.text = UpgradeRequirements[HouseLevel].Clay.ToString();
        }
        else if (House.gameObject.GetComponent<SpriteRenderer>().sprite == House_5)
        {
            Resource_4.enabled = false;
            HouseKost_4.enabled = false;
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stone.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Clay.ToString();
            HouseKost_3.text = UpgradeRequirements[HouseLevel].Wood.ToString();
            Resource_1.gameObject.GetComponent<Image>().sprite = Stone;
            Resource_2.gameObject.GetComponent<Image>().sprite = Clay;
        }
        else if (House.gameObject.GetComponent<SpriteRenderer>().sprite == House_6)
        {
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stone.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Clay.ToString();
            HouseKost_3.text = UpgradeRequirements[HouseLevel].Wood.ToString();
        }
        else if (House.gameObject.GetComponent<SpriteRenderer>().sprite == House_7)
        {
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stone.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Iron.ToString();
            HouseKost_3.text = UpgradeRequirements[HouseLevel].Wood.ToString();
            Resource_2.gameObject.GetComponent<Image>().sprite = Iron;
        }
    }
    IEnumerator RefreshCollider(Collider2D col)
    {
        col.enabled = false;

        // Wait a frame so the collider can update 
        // it's status to false 
        yield return null;

        // Enable
        col.enabled = true;

        yield return null;

        // Force an update to the collider logic by nudging the 
        // the transform but will ultimately not move the object
        col.transform.localPosition += new Vector3(0.01f, 0, 0);
        col.transform.localPosition += new Vector3(-0.01f, 0, 0);
    }


    public void ChangeHouse()
    {
        if (Inventory.Stick >= UpgradeRequirements[HouseLevel].Stick && Inventory.Straw >= UpgradeRequirements[HouseLevel].Straw &&
            Inventory.Clay >= UpgradeRequirements[HouseLevel].Clay && Inventory.Wood >= UpgradeRequirements[HouseLevel].Wood &&
            Inventory.Iron >= UpgradeRequirements[HouseLevel].Iron && Inventory.Pebble >= UpgradeRequirements[HouseLevel].Pebble &&
            Inventory.Stone >= UpgradeRequirements[HouseLevel].Stone && HouseBuild == false)
        {
            Inventory.Stick -= UpgradeRequirements[HouseLevel].Stick;
            Inventory.Straw -= UpgradeRequirements[HouseLevel].Straw;
            Inventory.Stone -= UpgradeRequirements[HouseLevel].Stone;
            Inventory.Clay -= UpgradeRequirements[HouseLevel].Clay;
            Inventory.Wood -= UpgradeRequirements[HouseLevel].Wood;
            Inventory.Iron -= UpgradeRequirements[HouseLevel].Iron;
            Inventory.Pebble -= UpgradeRequirements[HouseLevel].Pebble;

            HouseBuild = true;
            if (HouseCheck && HouseBuild)
            {
                HouseLevel += 1;
                House.gameObject.GetComponent<SpriteRenderer>().sprite = UpgradeHouse.gameObject.GetComponent<Image>().sprite;
                SetHouse();
                ChangeCosts();
                HouseBuild = false;
                HouseCheck = false;
            }
        }
        else if (HouseBuild == true)
        {
            popUp2.SetActive(true);
        }
        else
        {
            popUp1.SetActive(true);
        }
    }

    public void MakeHousePlans()
    {
        UpgradeRequirements = new Dictionary<int, HouseModel>();
        UpgradeRequirements.Add(1, HouseModel.houseModel_2);
        UpgradeRequirements.Add(2, HouseModel.houseModel_3);
        UpgradeRequirements.Add(3, HouseModel.houseModel_4);
        UpgradeRequirements.Add(4, HouseModel.houseModel_5);
        UpgradeRequirements.Add(5, HouseModel.houseModel_6);
        UpgradeRequirements.Add(6, HouseModel.houseModel_7);
        UpgradeRequirements.Add(7, HouseModel.houseModel_8);
    }

    public void ClosePopup()
    {
        popUp1.SetActive(false);
        popUp2.SetActive(false);
    }
}
