﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveMenuscript : MonoBehaviour {

    public static bool GameIsPaused = false;
    public static bool CaveCollision = false;

    public GameObject activeMenu;

    // Update is called once per frame
    void Update()
    {
        if (CaveCollision && !GameIsPaused)
        {
            PauseCave();
        }
        else
        {
            Resume();
            GameIsPaused = false;
            CaveCollision = false;
        }
    }

    public void Resume()
    {
        activeMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = true;
    }

    void PauseCave()
    {
        activeMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        CaveCollision = false;
        activeMenu.SetActive(false);
        GameIsPaused = true;
        SceneManager.LoadScene("Start Menu");
    }
}
