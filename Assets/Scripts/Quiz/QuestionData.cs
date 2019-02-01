using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData {
    public int Id;
    public string Vraag;
    public int Type;
    public AnswerData[] Antwoorden;
    public string Hint;
    public int MinLevel;
    public int MaxLevel;
    public bool Active;
}
