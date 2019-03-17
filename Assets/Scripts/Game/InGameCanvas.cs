using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class InGameCanvas : MonoBehaviour {

    APIManager apimanager;
    public GameObject popupScreen;

    public void OpenInventoryMenu()
    {
        InventoryMenu.InventoryCheck = true;
    }
    public void OpenPopup()
    {
        popupScreen.SetActive(true);
    }
    public void Resume()
    {
        popupScreen.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
