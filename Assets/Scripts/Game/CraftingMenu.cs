using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CraftingMenu : MonoBehaviour {

    public static bool GameIsPaused = true;
    public static bool WorkBench = false;

    public GameObject activeMenu;
    public GameObject otherMenu;
    public GameObject popUp;
    public GameObject InGameCanvas;

    private int AxeAmountInt_1 = 3;
    private int AxeAmountInt_2 = 3;
    private int PitchforkAmountInt_1 = 3;
    private int PitchforkAmountInt_2 = 3;
    private int PickaxeAmountInt_1 = 3;
    private int PickaxeAmountInt_2 = 3;

    public Text popUpText;
    public Text AxeAmount_1;
    public Text AxeAmount_2;
    public Text PitchforkAmount_1;
    public Text PitchforkAmount_2;
    public Text PickaxeAmount_1;
    public Text PickaxeAmount_2;
   
    void Start()
    {
        activeMenu.SetActive(false);
        WorkBench = false;
        Time.timeScale = 1f;

        AxeAmount_1.text = AxeAmountInt_1 + "x";
        AxeAmount_2.text = AxeAmountInt_2 + "x";
        PitchforkAmount_1.text = PitchforkAmountInt_1 + "x";
        PitchforkAmount_2.text = PitchforkAmountInt_2 + "x";
        PickaxeAmount_1.text = PickaxeAmountInt_1 + "x";
        PickaxeAmount_2.text = PickaxeAmountInt_2 + "x";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (WorkBench)
        {
            if (GameIsPaused)
            {
                PauseCrafting();
            }
            else
            {
                Resume();
                WorkBench = false;
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

    void PauseCrafting()
    {
        activeMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OtherMenu()
    {
        activeMenu.SetActive(false);
        otherMenu.SetActive(true);
    }

    public void checkAxeMaterials()
    {
        Debug.Log("Axe call");
        if(Inventory.Stick >= AxeAmountInt_1 && Inventory.Pebble >= AxeAmountInt_2 && Inventory.Axe == false)
        {
            Inventory.Stick = Inventory.Stick - AxeAmountInt_1;
            Inventory.Pebble = Inventory.Pebble - AxeAmountInt_2;
            Inventory.Axe = true;
        }
        else if (Inventory.Axe == true)
        {
            popUpText.text = "Je hebt al een Bijl";
            popUp.SetActive(true);
        }
        else
        {
            popUpText.text = "Je hebt niet genoeg materialen";
            popUp.SetActive(true);
        }
    }

    public void checkPitchforkMaterials()
    {
        if (Inventory.Stick >= PitchforkAmountInt_1 && Inventory.Pebble >= PitchforkAmountInt_2 && Inventory.Pitchfork == false)
        {
            Inventory.Stick = Inventory.Stick - PitchforkAmountInt_1;
            Inventory.Pebble = Inventory.Pebble - PitchforkAmountInt_2;
            Inventory.Pitchfork = true;
        }
        else if (Inventory.Pitchfork == true)
        {
            popUpText.text = "Je hebt al een Hooivork";
            popUp.SetActive(true);
        }
        else
        {
            popUpText.text = "Je hebt niet genoeg materialen";
            popUp.SetActive(true);
        }
    }

    public void checkPickAxeMaterial()
    {
        if (Inventory.Stick >= PickaxeAmountInt_1 && Inventory.Pebble >= PickaxeAmountInt_2 && Inventory.Pickaxe == false)
        {
            Inventory.Stick = Inventory.Stick - PickaxeAmountInt_1;
            Inventory.Pebble = Inventory.Pebble - PickaxeAmountInt_2;
            Inventory.Pickaxe = true;
        }
        else if (Inventory.Pickaxe == true)
        {
            popUpText.text = "Je hebt al een Houweel";
            popUp.SetActive(true);
        }
        else
        {
            popUpText.text = "Je hebt niet genoeg materialen";
            popUp.SetActive(true);
        }
    }

    public void ClosePopup()
    {
        popUp.SetActive(false);
    }
}
