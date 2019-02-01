using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public QuizData[] allQuizData;

    public static QuizData[] AllQuizData
    {
        get
        {
            return AllQuizData;
        }
        set
        {
            AllQuizData = value;
        }
    }
}