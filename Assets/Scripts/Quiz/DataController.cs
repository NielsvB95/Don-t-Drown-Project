using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour
{
    private QuizData[] allQuizData;
    private string gameDataFileName = "data2.json";
    private System.Random rnd = new System.Random();

    void Start()
    {
        LoadGameData();
    }

    public QuestionData GetQuestionData()
    {
        int questionCount = allQuizData[0].vragen.Length;
        int questionId = rnd.Next(0, questionCount);
        QuestionData questionData = allQuizData[0].vragen[questionId];
        return questionData;
    }

    private void LoadGameData()
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

            allQuizData = loadedData.allQuizData;
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
    }

}