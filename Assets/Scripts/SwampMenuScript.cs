﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwampMenuScript : MonoBehaviour {

    public static bool GameIsPaused = false;
    public static bool SwampCollision = false;

    public GameObject activeMenu;

    // Update is called once per frame
    void Update()
    {
        if (SwampCollision)
        {
            if (!GameIsPaused)
            {
                PauseSwamp();
            }
            else
            {
                Resume();
                GameIsPaused = false;
                SwampCollision = false;
            }
        }
    }

    public void Resume()
    {
        activeMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = true;
    }

    void PauseSwamp()
    {
        activeMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        GameIsPaused = true;
        SceneManager.LoadScene("Start Menu");
    }
}
