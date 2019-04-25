using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public Text questionDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject answerResultPanel;
    public Text answerResultText;
    public GameObject hintPanel;
    public Text hintText;
    public GameObject endQuizButton;

    public DataController dataController;
    public QuizController quizController;
    private QuestionData questionData;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();
    private GameObject questionTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowQuestion(GameObject gameObject)
    {
        questionTrigger = gameObject;
        RemoveAnswerButtons();
        questionData = dataController.GetQuestionData();
        questionDisplayText.text = questionData.Vraag;
        if (questionData.Hint != "")
        {
            hintText.text = questionData.Hint;
        }
        else
        {
            hintText.text = "Geen hint beschikbaar.";
        }

        int answerAmount = questionData.Antwoorden.Count;
        int intelligenceLevel = SaveData.IntelligenceLevel;

        if (intelligenceLevel >= 6)
        {
            answerAmount = answerAmount - 3;
        }
        else if (intelligenceLevel >= 3)
        {
            answerAmount = answerAmount - 2;
        }
        else if (intelligenceLevel >= 1)
        {
            answerAmount = answerAmount - 1;
        }

        if (answerAmount < 3)
        {
            if (questionData.Antwoorden.Count >= 3)
            {
                answerAmount = 3;
            }
            else
            {
                answerAmount = questionData.Antwoorden.Count;
            }
        }

        int index = 0;
        while (questionData.Antwoorden.Count > answerAmount)
        {
            if(questionData.Antwoorden[index].Correctness != 1)
            {
                questionData.Antwoorden.Remove(questionData.Antwoorden[index]);
            }
            index++;
        }

        questionData.Antwoorden.Shuffle();
        for (int i = 0; i < questionData.Antwoorden.Count; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.Antwoorden[i]);
        }
        endQuizButton.SetActive(false);
        questionDisplay.SetActive(true);
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(int isCorrect)
    {
        if (isCorrect == 1)
        {
            //increment correct answer amount by 1 for the given resource
            quizController.correctAnswers[questionTrigger.tag]++;
            answerResultText.text = "Antwoord is goed.";
            answerResultPanel.GetComponent<Image>().color = UnityEngine.Color.green;
        }
        else
        {
            answerResultText.text = "Antwoord is fout.";
            answerResultPanel.GetComponent<Image>().color = UnityEngine.Color.red;
        }
        Destroy(questionTrigger);
        questionDisplay.SetActive(false);
        answerResultPanel.SetActive(true);
    }

    public void CloseAnswerResultPanel()
    {
        endQuizButton.SetActive(true);
        answerResultPanel.SetActive(false);
        GameObject.Find("Player").GetComponent<Player_Movement>().enabled = true;
    }

    public void ShowHintPanel()
    {
        hintPanel.SetActive(true);
    }

    public void CloseHintPanel()
    {
        hintPanel.SetActive(false);
    }

}
