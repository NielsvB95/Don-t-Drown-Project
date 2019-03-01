using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class InGameCanvas : MonoBehaviour {

    APIManager apimanager;

    public void OpenInventoryMenu()
    {
        InventoryMenu.InventoryCheck = true;
    }

    void Start()
    {
    }
    
}
