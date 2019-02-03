using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherMaterialsMenu : MonoBehaviour {

    public GameObject activeMenu;
    public GameObject otherMenu;
    public GameObject popUp;

    private int StrengthAmountInt_1 = 1;
    private int StrengthAmountInt_2 = 1;
    private int StrengthAmountInt_3 = 1;

    private int ConstitutionAmountInt_1 = 2;

    private int IntelligenceAmountInt_1 = 2;
    private int IntelligenceAmountInt_2 = 1;

    private int WisdomAmountInt_1 = 2;

    public Text StrengthAmount_1;
    public Text StrengthAmount_2;
    public Text StrengthAmount_3;

    public Text ConstitutionAmount_1;

    public Text IntelligenceAmount_1;
    public Text IntelligenceAmount_2;

    public Text WisdomAmount_1;

    void Start()
    {
        StrengthAmount_1.text = StrengthAmountInt_1 + "x";
        StrengthAmount_2.text = StrengthAmountInt_2 + "x";
        StrengthAmount_3.text = StrengthAmountInt_3 + "x";

        ConstitutionAmount_1.text = ConstitutionAmountInt_1 + "x";

        IntelligenceAmount_1.text = IntelligenceAmountInt_1 + "x";
        IntelligenceAmount_2.text = IntelligenceAmountInt_2 + "x";

        WisdomAmount_1.text = WisdomAmountInt_1 + "x";
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

    public void checkWisdomPotionMaterials()
    {
        if (Inventory.Flower >= StrengthAmountInt_1 && Inventory.Mushroom >= StrengthAmountInt_2 && Inventory.Gemstone >= StrengthAmountInt_3)
        {
            Inventory.WisdomPotion += 1;
            Inventory.Flower -= StrengthAmountInt_1;
            Inventory.Mushroom -= StrengthAmountInt_2;
            Inventory.Gemstone -= StrengthAmountInt_3;
        }
        else
        {
            popUp.SetActive(true);
        }
    }
    /*
    public void checkConstitutionPotionMaterials()
    {
        if(Inventory.Flower == ConstitutionAmountInt_1)
        {
            Inventory.ConstitutionPotion += 1;
            Inventory.Flower -= ConstitutionAmountInt_1;
        }
        else
        {
            popUp.SetActive(true);
        }
    }

    public void checkIntelligencePotionMaterials()
    {
        if (Inventory.Mushroom >= IntelligenceAmountInt_1 && Inventory.Flower >= IntelligenceAmountInt_2)
        {
            Inventory.IntelligencePotion += 1;
            Inventory.Mushroom -= IntelligenceAmountInt_1;
            Inventory.Flower -= IntelligenceAmountInt_2;
        }
        else
        {
            popUp.SetActive(true);
        }
    }
    
    public void checkStrengthPotionMaterials()
    {
        if (Inventory.Gemstone >= WisdomAmountInt_1)
        {
            Inventory.WisdomPotion += 1;
            Inventory.Gemstone -= WisdomAmountInt_1;
        }
        else
        {
            popUp.SetActive(true);
        }
    }
    */
    public void ClosePopup()
    {
        popUp.SetActive(false);
    }
}
