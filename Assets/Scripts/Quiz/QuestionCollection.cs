using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionCollection {

    public QuestionData[] questions;
    public string collectionName;

    public override string ToString()
    {
        string result = "QUESTIONS\n";
        foreach(var question in questions)
        {
            result += string.Format("Question: {0}\nAnswer: {1}\n\n", question.questionText, question.answers);
        }
        return result;
    }

}
