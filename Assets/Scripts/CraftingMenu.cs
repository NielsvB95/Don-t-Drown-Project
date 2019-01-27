using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CraftingMenu : MonoBehaviour {

    public static bool GameIsPaused = true;
    public static bool WorkBench = false;

    private int AxeAmountInt_1 = 4;
    private int AxeAmountInt_2 = 2;
    private int PitchforkAmountInt_1 = 3;
    private int PitchforkAmountInt_2 = 2;
    private int PickaxeAmountInt_1 = 4;
    private int PickaxeAmountInt_2 = 3;

    public GameObject activeMenu;
    public GameObject otherMenu;
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
                Debug.Log("Else statement craftingMenu WorkBench:" + WorkBench + GameIsPaused);
            }
        }
    }

    public void Resume()
    {
        activeMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resume CraftingMenu is called");
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

    }

    public void checkPickAxeMaterial()
    {

    }

    public void checkPitchforkMaterials()
    {

    }
}
