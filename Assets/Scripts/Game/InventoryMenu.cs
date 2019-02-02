using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour {

    public static bool GameIsPaused = true;
    public static bool InventoryCheck = false;

    public GameObject activeMenu;

    public GameObject AxeCheck;
    public GameObject PitchforkCheck;
    public GameObject PickaxeCheck;
    private int Stick = Inventory.Stick;
    private int Wood = Inventory.Wood;
    private int Straw = Inventory.Straw;
    private int Clay = Inventory.Clay;
    private int Stone = Inventory.Stone;
    private int Pebble = Inventory.Pebble;
    private int Iron = Inventory.Iron;
    private int Flower = Inventory.Flower;
    private int Mushroom = Inventory.Mushroom;
    private int Gemstone = Inventory.Gemstone;
    private int StrengthPotion = Inventory.StrengthPotion;
    private int ConstitutionPotion = Inventory.ConstitutionPotion;
    private int IntelligencePotion = Inventory.IntelligencePotion;
    private int WisdomPotion = Inventory.WisdomPotion;
  
    public Text Stick_Amount;
    public Text Wood_Amount;
    public Text Straw_Amount;
    public Text Clay_Amount;
    public Text Stone_Amount;
    public Text Pebble_Amount;
    public Text Iron_Amount;
    public Text Flower_Amount;
    public Text Mushroom_Amount;
    public Text Gemstone_Amount;

    public Text StrengthPotion_Amount;
    public Text ConstitutionPotion_Amount;
    public Text IntelligencePotion_Amount;
    public Text WisdomPotion_Amount;

    void Start()
    {
        Stick_Amount.text = Stick + "x";
        Wood_Amount.text = Wood + "x";
        Straw_Amount.text = Straw + "x";
        Clay_Amount.text = Clay + "x";
        Stone_Amount.text = Stone + "x";
        Pebble_Amount.text = Pebble + "x";
        Iron_Amount.text = Iron + "x";
        Flower_Amount.text = Flower + "x";
        Mushroom_Amount.text = Mushroom + "x";
        Gemstone_Amount.text = Gemstone + "x";
        StrengthPotion_Amount.text = StrengthPotion + "x";
        ConstitutionPotion_Amount.text = ConstitutionPotion + "x";
        IntelligencePotion_Amount.text = IntelligencePotion + "x";
        WisdomPotion_Amount.text = WisdomPotion + "x";


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

    // Update is called once per frame
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
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseInventory()
    {
        activeMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
