using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherMaterialsMenu : MonoBehaviour {

    private int PotionAmountInt_1 = 3;
    private int PotionAmountInt_2 = 3;

    public GameObject activeMenu;
    public GameObject otherMenu;
    public Text PotionAmount_1;
    public Text PotionAmount_2;
   

    void Start()
    {
        PotionAmount_1.text = PotionAmountInt_1 + "x";
        PotionAmount_2.text = PotionAmountInt_2 + "x";
    }

    // Update is called once per frame
    
    public void Resume()
    {
        activeMenu.SetActive(false);
        CraftingMenu.WorkBench = false;
        Time.timeScale = 1f;
        Debug.Log("Resume OtherMenu is called");
    }

    public void OtherMenu()
    {
        activeMenu.SetActive(false);
        otherMenu.SetActive(true);
    }

    public void checkPotionMaterials()
    {

    }
}
