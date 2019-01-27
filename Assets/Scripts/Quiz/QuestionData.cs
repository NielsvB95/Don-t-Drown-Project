using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData {
    public int id;
    public string vraag;
    public int type;
    public AnswerData[] antwoorden;
    public string hint;
    public int minLevel;
    public int maxLevel;
    public bool active;
}
