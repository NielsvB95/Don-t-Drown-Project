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

    public DataController dataController;
    private QuestionData questionData;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();
    private GameObject questionTrigger;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
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
        questionDisplayText.text = questionData.vraag;

        for (int i = 0; i < questionData.antwoorden.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.antwoorden[i]);
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
            playerScore++;
            Destroy(questionTrigger);
            questionDisplay.SetActive(false);
        }
        else
        {
            questionDisplay.SetActive(false);
        }

    }


}
