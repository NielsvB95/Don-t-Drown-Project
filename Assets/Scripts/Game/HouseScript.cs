using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject InGameCanvas;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            HouseMenu.HouseMenuCheck = true;
            InGameCanvas.SetActive(false);
        }
    }
}
