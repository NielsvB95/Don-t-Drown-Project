using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseMenu : MonoBehaviour
{
    public HouseSpriteRecipe CurrentHouseModel;

    public List<Sprite> Sprites;

    public Sprite Stick;
    public Sprite Clay;
    public Sprite Straw;
    public Sprite Wood;
    public Sprite Stone;
    public Sprite Iron;
    
    private Sprite CurrentSprite;

    private HouseSpriteRecipe CurrentHouse;
    private HouseSpriteRecipe UpgradeHouse;

    public GameObject House;

    public Image CurrentHouseImage;
    public Image UpgradeHouseImage;
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
    public Collider2D target;

    void Start()
    {
        if (SaveData.Request == true)
        {
            UpgradeButton.SetActive(false);
        }
        HouseLevel = SaveData.Level;
        CurrentHouse = GetHouse(HouseLevel);
        UpgradeHouse = GetHouse(HouseLevel + 1);
        SetHouse();
        MakeHousePlans();
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

    public HouseSpriteRecipe GetHouse(int upgrade)
    {
        
        switch (upgrade)
        {
            case 1:
                return HouseSpriteRecipe.House_1;
            case 2:
                return HouseSpriteRecipe.House_2;
            case 3:
                return HouseSpriteRecipe.House_3;
            case 4:
                return HouseSpriteRecipe.House_4;
            case 5:
                return HouseSpriteRecipe.House_5;
            case 6:
                return HouseSpriteRecipe.House_6;
            case 7:
                return HouseSpriteRecipe.House_7;
            case 8:
                return HouseSpriteRecipe.House_8;
        }
        return null;
    }

    public void SetHouse()
    {
        CurrentSprite = CurrentHouse.HouseImage;
        CurrentHouseImage.gameObject.GetComponent<Image>().sprite = CurrentSprite;
        House.gameObject.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
        House.AddComponent<PolygonCollider2D>();
        if (CurrentSprite == HouseSpriteRecipe.House_8.HouseImage)
        {
            Destroy(UpgradeHouseImage);
            UpgradeButton.SetActive(false);
        }
        else
        {
            UpgradeHouseImage.gameObject.GetComponent<Image>().sprite = UpgradeHouse.HouseImage;
        }       
    }

    public void ChangeCosts()
    {
        if (UpgradeHouse.HouseImage == HouseSpriteRecipe.House_2.HouseImage)
        {
            Resource_3.enabled = false;
            Resource_3.enabled = false;
            Resource_4.enabled = false;
            HouseKost_4.enabled = false;
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stick.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Straw.ToString();
        }
        else if (UpgradeHouse.HouseImage == HouseSpriteRecipe.House_3.HouseImage)
        {
            Resource_3.enabled = false;
            Resource_3.enabled = false;
            Resource_4.enabled = false;
            HouseKost_4.enabled = false;
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stick.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Straw.ToString();
        }
        else if (UpgradeHouse.HouseImage == HouseSpriteRecipe.House_4.HouseImage)
        {
            Resource_3.enabled = true;
            HouseKost_3.enabled = true;
            Resource_4.enabled = false;
            HouseKost_4.enabled = false;
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stick.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Straw.ToString();
            HouseKost_3.text = UpgradeRequirements[HouseLevel].Wood.ToString();
        }
        else if (UpgradeHouse.HouseImage == HouseSpriteRecipe.House_5.HouseImage)
        {
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stick.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Straw.ToString();
            HouseKost_3.text = UpgradeRequirements[HouseLevel].Wood.ToString();
            HouseKost_4.text = UpgradeRequirements[HouseLevel].Clay.ToString();
        }
        else if (UpgradeHouse.HouseImage == HouseSpriteRecipe.House_6.HouseImage)
        {
            Resource_4.enabled = false;
            HouseKost_4.enabled = false;
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stone.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Clay.ToString();
            HouseKost_3.text = UpgradeRequirements[HouseLevel].Wood.ToString();
            Resource_1.gameObject.GetComponent<Image>().sprite = Stone;
            Resource_2.gameObject.GetComponent<Image>().sprite = Clay;
        }
        else if (UpgradeHouse.HouseImage == HouseSpriteRecipe.House_7.HouseImage)
        {
            Resource_4.enabled = false;
            HouseKost_4.enabled = false;
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stone.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Clay.ToString();
            HouseKost_3.text = UpgradeRequirements[HouseLevel].Wood.ToString();
        }
        else if (UpgradeHouse.HouseImage == HouseSpriteRecipe.House_8.HouseImage)
        {
            Resource_4.enabled = false;
            HouseKost_4.enabled = false;
            HouseKost_1.text = UpgradeRequirements[HouseLevel].Stone.ToString();
            HouseKost_2.text = UpgradeRequirements[HouseLevel].Iron.ToString();
            HouseKost_3.text = UpgradeRequirements[HouseLevel].Wood.ToString();
            Resource_2.gameObject.GetComponent<Image>().sprite = Iron;
        }
    }
    /*
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
        Debug.Log("refreshed collider");
    }
    */

    public void ChangeHouse()
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

            SaveData.Request = true;
            Debug.Log(SaveData.Request);
            UpgradeButton.SetActive(false);
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
