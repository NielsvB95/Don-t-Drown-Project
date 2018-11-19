using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForrestMenuScript : MonoBehaviour {
    public static bool GameIsPaused = false;
    public static bool ForrestCollision = false;

    public GameObject activeMenu;

    // Update is called once per frame
    void Update()
    {
        if (ForrestCollision)
        {
            if (!GameIsPaused)
            {
                PauseForrest();
            }
            else
            {
                Resume();
                GameIsPaused = false;
                ForrestCollision = false;
            }
        }
    }

    public void Resume()
    {
        activeMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = true;
    }

    void PauseForrest()
    {
        activeMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
