using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{

    public Text timeRemainingDisplayText;
    public GameObject quizEndDisplay;
    public float timeLimit;
    public GameObject questionDisplay;

    private bool isQuizActive;
    private float timeRemaining;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        
        timeRemaining = timeLimit;
        UpdateTimeRemainingDisplay();
        isQuizActive = true;

    }

    public void EndQuiz()
    {
        isQuizActive = false;
        questionDisplay.SetActive(false);
        quizEndDisplay.SetActive(true);
    }

    public void ReturnToGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Tijd: " + Mathf.Round(timeRemaining).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isQuizActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                EndQuiz();
            }

        }
    }
}

