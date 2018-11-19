using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForrestScript : MonoBehaviour {

    public GameObject Player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            ForrestMenuScript.ForrestCollision = true;
            //menuscript.GetGameObject(ForrestMenu);
        }
    }
}
