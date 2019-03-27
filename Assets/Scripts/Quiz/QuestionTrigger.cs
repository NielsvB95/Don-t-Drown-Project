using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    public GameObject Player;
    public QuestionController questionController;
    public GameObject missingToolPanel;
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
                questionController.ShowQuestion(gameObject);
            }
            else
            {
                missingToolPanel.SetActive(true);
            }
        }
    }
}
