using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionTrigger : MonoBehaviour
{
    public GameObject Player;
    public QuestionController questionController;
    public GameObject warningPanel;
    public Text warningPanelText;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            Player.GetComponent<Player_Movement>().enabled = false;

            string resource = gameObject.tag;
            bool allowed = false;

            switch (resource)
            {
                case "Wood":
                    allowed = Inventory.Axe;
                    break;
                case "Stone":
                case "Iron":
                case "Gemstone":
                    allowed = Inventory.Pickaxe;
                    break;
                case "Straw":
                    allowed = Inventory.Pitchfork;
                    break;
                case "Stick":
                case "Pebble":
                case "Grass":
                case "Flower":
                case "Mushroom":
                    allowed = true;
                    break;
            }

            if (allowed)
            {
                switch (resource)
                {
                    case "Iron":
                        if(SaveData.WisdomLevel < 6)
                        {
                            warningPanelText.text = "Je wisdom moet minimaal level 6 zijn om deze grondstof te verzamelen.";
                            warningPanel.SetActive(true);
                        }
                        else
                        {
                            questionController.ShowQuestion(gameObject);
                        }
                        break;
                    default:
                        questionController.ShowQuestion(gameObject);
                        break;
                }
            }
            else
            {
                warningPanelText.text = "Je bezit niet het juiste gereedschap om deze grondstof te verzamelen.";
                warningPanel.SetActive(true);
            }
        }
    }
}
