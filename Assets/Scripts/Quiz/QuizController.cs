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
    public GameObject endQuizButton;
    public float baseTimeLimit;
    public GameObject questionDisplay;
    public GameObject missingToolPanel;
    public GameObject randomChanceResourceOne;
    public GameObject randomChanceResourceTwo;
    public GameObject randomChanceResourceThree;
    public int forceSpawnAfter;
    public APIManager apiManager;
    public Dictionary<string, int> correctAnswers = new Dictionary<string, int>
    {
        {"Stick", 0},
        {"Wood", 0},
        {"Stone", 0},
        {"Grass", 0},
        {"Iron", 0},
        {"Straw", 0},
        {"Mushroom", 0},
        {"Flower", 0},
        {"Gemstone", 0},
        {"Pebble", 0}
    };

    private bool isQuizActive;
    private float timeRemaining;
    private string resultText;

    // Use this for initialization
    void Start()
    {
        SpawnRandomChanceResource();
        Time.timeScale = 1f;
        timeRemaining = baseTimeLimit + SaveData.ConstitutionLevel * 10;
        UpdateTimeRemainingDisplay();
        isQuizActive = true;
    }

    public void SpawnRandomChanceResource()
    {
        bool forceSpawn = false;
        bool spawned = false;
        int randomNumber = Random.Range(0, 100);
        string scene = SceneManager.GetActiveScene().name;
        
        switch (scene)
        {
            case "Forrest":
                if(SaveData.MushroomSpawn >= forceSpawnAfter)
                {
                    forceSpawn = true;
                }
                break;
            case "Cave":
                if (SaveData.GemstoneSpawn >= forceSpawnAfter)
                {
                    forceSpawn = true;
                }
                break;
            case "Meadow":
                if (SaveData.FlowerSpawn >= forceSpawnAfter)
                {
                    forceSpawn = true;
                }
                break;
        }

        if (randomNumber < 5 || forceSpawn == true)
        {
            randomChanceResourceOne.SetActive(true);
            spawned = true;
        }
        else if (randomNumber < 10)
        {
            randomChanceResourceTwo.SetActive(true);
            spawned = true;
        }
        else if (randomNumber < 15)
        {
            randomChanceResourceThree.SetActive(true);
            spawned = true;
        }
        else
        {
            switch (scene)
            {
                case "Forrest":
                    SaveData.MushroomSpawn++;
                    break;
                case "Cave":
                    SaveData.GemstoneSpawn++;
                    break;
                case "Meadow":
                    SaveData.FlowerSpawn++;
                    break;
            }
        }

        if (spawned == true)
        {
            switch (scene)
            {
                case "Forrest":
                    SaveData.MushroomSpawn = 0;
                    break;
                case "Cave":
                    SaveData.GemstoneSpawn = 0;
                    break;
                case "Meadow":
                    SaveData.FlowerSpawn = 0;
                    break;
            }
        }
    }

    public void EndQuiz()
    {
        isQuizActive = false;
        endQuizButton.SetActive(false);
        AwardResources();
        questionDisplay.SetActive(false);
        quizEndDisplayText.text = resultText;
        quizEndDisplay.SetActive(true);
        apiManager.SaveGame();
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
        if (correctAnswers["Grass"] >= 3)
        {
            resultText += "Gras: 1\n";
            Inventory.Grass++;
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
        if (correctAnswers["Flower"] >= 1)
        {
            resultText += "Bloem: 1\n";
            Inventory.Flower++;
        }
        if (correctAnswers["Gemstone"] >= 1)
        {
            resultText += "Edelsteen: 1\n";
            Inventory.Gemstone++;
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

