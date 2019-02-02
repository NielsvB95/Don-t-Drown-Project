using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public GameObject AxeButton;

    void Start()
    {
        checkAxe();
    }

    // Use this for initialization
    public void StartGame () {
        SceneManager.LoadScene("Game");
	}
    
    public void checkAxe()
    {
        if (Player_Movement.hasAxe)
        {
            AxeButton.SetActive(true);
        }
    }
}
