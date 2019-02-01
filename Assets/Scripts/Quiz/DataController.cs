using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System.Net;

public class DataController : MonoBehaviour
{
    private QuizData[] allQuizData;
    private System.Random rnd = new System.Random();

    void Awake()
    {
        LoadQuizData();
    }

    public QuestionData GetQuestionData()
    {
        int questionCount = allQuizData[0].vragen.Length;
        int questionId = rnd.Next(0, questionCount);
        QuestionData questionData = allQuizData[0].vragen[questionId];
        return questionData;
    }

    private void LoadQuizData()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://dontdrown.nl/api/vraag");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        string JSONToParse = "{\"allQuizData\":[{\"vragen\": " + jsonResponse + "}]}";
        GameData loadedData = JsonUtility.FromJson<GameData>(JSONToParse);
        allQuizData = loadedData.allQuizData;
    }

}