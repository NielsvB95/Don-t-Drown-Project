using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System.Net;

public class DataController : MonoBehaviour
{
    private QuizData[] allQuizData = GameData.AllQuizData;
    private System.Random rnd = new System.Random();

    public QuestionData GetQuestionData()
    {
        int questionCount = allQuizData[0].vragen.Length;
        int questionId = rnd.Next(0, questionCount);
        QuestionData questionData = allQuizData[0].vragen[questionId];
        return questionData;
    }
}