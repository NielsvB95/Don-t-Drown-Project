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

        for (int i = 0; i < questionData.Antwoorden.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.Antwoorden[i]);
        }

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
            //remove the object that spawned the question from game world, since answer was correct
            Destroy(questionTrigger);
            answerResultText.text = "Antwoord is goed.";
            answerResultPanel.GetComponent<Image>().color = UnityEngine.Color.green;
            questionDisplay.SetActive(false);
            answerResultPanel.SetActive(true);
        }
        else
        {
            answerResultText.text = "Antwoord is fout.";
            answerResultPanel.GetComponent<Image>().color = UnityEngine.Color.red;
            questionDisplay.SetActive(false);
            answerResultPanel.SetActive(true);
        }
    }

    public void CloseAnswerResultPanel()
    {
        answerResultPanel.SetActive(false);
        GameObject.Find("Player").GetComponent<Player_Movement>().enabled = true;
    }

}
