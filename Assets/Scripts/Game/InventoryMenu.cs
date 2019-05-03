using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour {

    public static bool GameIsPaused = true;
    public static bool InventoryCheck = false;

    public GameObject activeMenu;
    public GameObject InGameCanvas;

    public GameObject AxeCheck;
    public GameObject PitchforkCheck;
    public GameObject PickaxeCheck;
    public GameObject popUp;

    public Text GatheringSkill;
    public Text EnduranceSkill;
    public Text IntelligenceSkill;
    public Text WisdomSkill;

    public Text Stick_Amount;
    public Text Wood_Amount;
    public Text Straw_Amount;
    public Text Grass_Amount;
    public Text Stone_Amount;
    public Text Pebble_Amount;
    public Text Iron_Amount;
    public Text Flower_Amount;
    public Text Mushroom_Amount;
    public Text Gemstone_Amount;

    public Text GatheringPotion_Amount;
    public Text Endurance_Potion_Amount;
    public Text IntelligencePotion_Amount;
    public Text WisdomPotion_Amount;

    void Start()
    {
        SetInventory();
    }

    public void SetInventory()
    {
        Stick_Amount.text = Inventory.Stick + "x";
        Wood_Amount.text = Inventory.Wood + "x";
        Straw_Amount.text = Inventory.Straw + "x";
        Grass_Amount.text = Inventory.Grass + "x";
        Stone_Amount.text = Inventory.Stone + "x";
        Pebble_Amount.text = Inventory.Pebble + "x";
        Iron_Amount.text = Inventory.Iron + "x";
        Flower_Amount.text = Inventory.Flower + "x";
        Mushroom_Amount.text = Inventory.Mushroom + "x";
        Gemstone_Amount.text = Inventory.Gemstone + "x";
        GatheringPotion_Amount.text = Inventory.GatheringPotion + "x";
        Endurance_Potion_Amount.text = Inventory.EndurancePotion + "x";
        IntelligencePotion_Amount.text = Inventory.IntelligencePotion + "x";
        WisdomPotion_Amount.text = Inventory.WisdomPotion + "x";
        GatheringSkill.text = SaveData.GatheringLevel + "";
        EnduranceSkill.text = SaveData.EnduranceLevel + "";
        IntelligenceSkill.text = SaveData.IntelligenceLevel + "";
        WisdomSkill.text = SaveData.WisdomLevel + "";


        if (Inventory.Axe)
        {
            AxeCheck.SetActive(false);
        }

        if (Inventory.Pitchfork)
        {
            PitchforkCheck.SetActive(false);
        }

        if (Inventory.Pickaxe)
        {
            PickaxeCheck.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (InventoryCheck)
        {
            if (GameIsPaused)
            {
                PauseInventory();
            }
            else
            {
                Resume();
                InventoryCheck = false;
                GameIsPaused = true;
            }
        }
    }

    public void Resume()
    {
        activeMenu.SetActive(false);
        InGameCanvas.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseInventory()
    {
        SetInventory();
        activeMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void checkGatheringPotion()
    {
        if(Inventory.GatheringPotion > 0)
        {
            SaveData.GatheringLevel ++;
            Inventory.GatheringPotion --;
            GatheringPotion_Amount.text = Inventory.GatheringPotion + "x";
            GatheringSkill.text = SaveData.GatheringLevel + "";
        }
        else
        {
            popUp.SetActive(true);
        }
    }

    public void checkEndurancePotion()
    {
        if (Inventory.EndurancePotion > 0)
        {
            SaveData.EnduranceLevel ++;
            Inventory.EndurancePotion --;
            Endurance_Potion_Amount.text = Inventory.EndurancePotion + "x";
            EnduranceSkill.text = SaveData.EnduranceLevel + "";
        }
        else
        {
            popUp.SetActive(true);
        }
    }

    public void checkIntelligencePotion()
    {
        if (Inventory.IntelligencePotion > 0)
        {
            SaveData.IntelligenceLevel ++;
            Inventory.IntelligencePotion --;
            IntelligencePotion_Amount.text = Inventory.IntelligencePotion + "x";
            IntelligenceSkill.text = SaveData.IntelligenceLevel + "";
        }
        else
        {
            popUp.SetActive(true);
        }
    }

    public void checkWisdomPotion()
    {
        if (Inventory.WisdomPotion > 0)
        {
            SaveData.WisdomLevel ++;
            Inventory.WisdomPotion --;
            WisdomPotion_Amount.text = Inventory.WisdomPotion + "x";
            WisdomSkill.text = SaveData.WisdomLevel + "";
        }
        else
        {
            popUp.SetActive(true);
        }
    }

    public void ClosePopup()
    {
        popUp.SetActive(false);
    }
}
