using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveMenuscript : MonoBehaviour {

    public static bool GameIsPaused = true;
    public static bool CaveCollision = false;
    public GameObject StartQuizButton;

    public GameObject activeMenu;

    void Start()
    {
        activeMenu.SetActive(false);
        CaveCollision = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CaveCollision)
        {
            if (GameIsPaused)
            {
                PauseCave();
            }
            else
            {
                Resume();
                GameIsPaused = true;
                CaveCollision = false;
            }
        }
    }

    public void Resume()
    {
        activeMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseCave()
    {
        activeMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        GameIsPaused = true;
        Datamanager.playerPosition = new Vector3(5, -2, 0);
        SceneManager.LoadScene("Cave");
    }
}
