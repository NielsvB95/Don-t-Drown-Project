using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherMaterialsMenu : MonoBehaviour {

    public GameObject activeMenu;
    public GameObject otherMenu;
    public GameObject popUp;
    public GameObject InGameCanvas;

    private int GatheringAmountInt_1 = 1;
    private int GatheringAmountInt_2 = 1;
    private int GatheringAmountInt_3 = 1;

    private int EnduranceAmountInt_1 = 2;

    private int IntelligenceAmountInt_1 = 2;
    private int IntelligenceAmountInt_2 = 1;

    private int WisdomAmountInt_1 = 2;

    public Text GatheringAmount_1;
    public Text GatheringAmount_2;
    public Text GatheringAmount_3;

    public Text EnduranceAmount_1;

    public Text IntelligenceAmount_1;
    public Text IntelligenceAmount_2;

    public Text WisdomAmount_1;

    void Start()
    {
        GatheringAmount_1.text = GatheringAmountInt_1 + "x";
        GatheringAmount_2.text = GatheringAmountInt_2 + "x";
        GatheringAmount_3.text = GatheringAmountInt_3 + "x";

        EnduranceAmount_1.text = EnduranceAmountInt_1 + "x";

        IntelligenceAmount_1.text = IntelligenceAmountInt_1 + "x";
        IntelligenceAmount_2.text = IntelligenceAmountInt_2 + "x";

        WisdomAmount_1.text = WisdomAmountInt_1 + "x";
        checkAllMaterials();
    }

    // Update is called once per frame

    public void Resume()
    {
        activeMenu.SetActive(false);
        CraftingMenu.WorkBench = false;
        InGameCanvas.SetActive(true);
        Time.timeScale = 1f;
        Debug.Log("Resume OtherMenu is called");
    }

    public void OtherMenu()
    {
        activeMenu.SetActive(false);
        otherMenu.SetActive(true);
    }

    public void checkAllMaterials()
    {
        checkMaterials(GatheringAmount_1, GatheringAmount_2, GatheringAmount_3, Inventory.Flower, Inventory.Mushroom, Inventory.Gemstone, GatheringAmountInt_1, GatheringAmountInt_2, GatheringAmountInt_3);
        checkMaterials(EnduranceAmount_1, null, null, Inventory.Flower, 0, 0, EnduranceAmountInt_1, 0, 0);
        checkMaterials(IntelligenceAmount_1, IntelligenceAmount_2, null, Inventory.Mushroom, Inventory.Flower, 0, IntelligenceAmountInt_1, IntelligenceAmountInt_2, 0);
        checkMaterials(WisdomAmount_1, null, null, Inventory.Gemstone, 0, 0, WisdomAmountInt_1, 0, 0);
    }

    public void checkMaterials(Text firstMaterial, Text secondMaterial, Text thirdMaterial, int firstItem, int secondItem, int thridItem, int firstAmount, int secondAmount, int thirdAmount)
    {
        Debug.Log("check materials");
        if (firstItem < firstAmount)
        {
            firstMaterial.color = Color.red;
        }
        if (secondItem < secondAmount)
        {
            secondMaterial.color = Color.red;
        }
        if (thridItem < thirdAmount)
        {
            thirdMaterial.color = Color.red;
        }
    }

    public void checkGatheringPotionMaterials()
    {
        if (Inventory.Flower >= GatheringAmountInt_1 && Inventory.Mushroom >= GatheringAmountInt_2 && Inventory.Gemstone >= GatheringAmountInt_3)
        {
            Inventory.GatheringPotion += 1;
            Inventory.Flower -= GatheringAmountInt_1;
            Inventory.Mushroom -= GatheringAmountInt_2;
            Inventory.Gemstone -= GatheringAmountInt_3;
        }
        else
        {
            popUp.SetActive(true);
        }
        checkAllMaterials();
    }

    public void checkEndurancePotionMaterials()
    {
        if(Inventory.Flower == EnduranceAmountInt_1)
        {
            Inventory.EndurancePotion += 1;
            Inventory.Flower -= EnduranceAmountInt_1;
        }
        else
        {
            popUp.SetActive(true);
        }
        checkAllMaterials();
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
        checkAllMaterials();
    }
    
    public void checkWisdomPotionMaterials()
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
        checkAllMaterials();
    }

    public void ClosePopup()
    {
        popUp.SetActive(false);
    }
}
