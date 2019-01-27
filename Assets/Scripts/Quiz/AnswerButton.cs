using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

    public Text answerText;

    private AnswerData answerData;
    private QuestionController questionController;

    // Use this for initialization
    void Start()
    {
        questionController = FindObjectOfType<QuestionController>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.waarde;
    }


    public void HandleClick()
    {
        questionController.AnswerButtonClicked(answerData.correctness);
    }
}
