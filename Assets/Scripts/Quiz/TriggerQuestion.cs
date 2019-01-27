using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuestion : MonoBehaviour
{
    public GameObject Player;
    public QuestionController questionController;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            questionController.ShowQuestion(gameObject);
        }
    }
}
