using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForrestMenuScript : MonoBehaviour {

    public static bool GameIsPaused = false;
    public static bool ForrestCollision = false;
    public GameObject StartQuizButton;

    public GameObject activeMenu;

    void Start()
    {
        activeMenu.SetActive(false);
        ForrestCollision = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkAxe();
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

    public void Quit()
    {
        GameIsPaused = true;
        Datamanager.playerPosition = new Vector3(-4.5f, 2, 0);
        SceneManager.LoadScene("Quiz");
    }

    public void checkAxe()
    {
        if (Player_Movement.hasAxe)
        {
            StartQuizButton.SetActive(true);
        }
    }
}
