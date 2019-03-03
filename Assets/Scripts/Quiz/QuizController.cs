using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizController : MonoBehaviour
{
    public Text timeRemainingDisplayText;
    public GameObject quizEndDisplay;
    public Text quizEndDisplayText;
    public float timeLimit;
    public GameObject questionDisplay;
    public GameObject missingToolPanel;
    public Dictionary<string, int> correctAnswers = new Dictionary<string, int>
    {
        {"Stick", 0},
        {"Wood", 0},
        {"Stone", 0},
        {"Clay", 0},
        {"Iron", 0},
        {"Straw", 0},
        {"Mushroom", 0},
        {"Flower", 0},
        {"Pebble", 0}
    };

    private bool isQuizActive;
    private float timeRemaining;
    private string resultText;

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
        AwardResources();
        questionDisplay.SetActive(false);
        quizEndDisplayText.text = resultText;
        quizEndDisplay.SetActive(true);
    }

    public void ReturnToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void CloseMissingToolPanel()
    {
        missingToolPanel.SetActive(false);
        GameObject.Find("Player").GetComponent<Player_Movement>().enabled = true;
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Tijd: " + Mathf.Round(timeRemaining).ToString();
    }

    private void AwardResources()
    {
        resultText = "Quiz afgelopen. Je hebt de volgende spullen verzameld:\n";
        if (correctAnswers["Pebble"] >= 3)
        {
            Inventory.Pebble++;
            resultText += "Kiezel: 1\n";
        }
        if (correctAnswers["Stick"] >= 3)
        {
            Inventory.Stick++;
            resultText += "Stok: 1\n";
        }
        if (correctAnswers["Wood"] >= 3)
        {
            resultText += "Hout: 1\n";
            Inventory.Wood++;
        }
        if (correctAnswers["Stone"] >= 3)
        {
            resultText += "Steen: 1\n";
            Inventory.Stone++;
        }
        if (correctAnswers["Clay"] >= 3)
        {
            resultText += "Klei: 1\n";
            Inventory.Clay++;
        }
        if (correctAnswers["Iron"] >= 3)
        {
            resultText += "IJzer: 1\n";
            Inventory.Iron++;
        }
        if (correctAnswers["Straw"] >= 3)
        {
            resultText += "Stro: 1\n";
            Inventory.Straw++;
        }
        if (correctAnswers["Mushroom"] >= 1)
        {
            resultText += "Paddenstoel: 1\n";
            Inventory.Mushroom++;
        }
        if (correctAnswers["Flower"] >= 3)
        {
            resultText += "Bloem: 1\n";
            Inventory.Flower++;
        }
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

