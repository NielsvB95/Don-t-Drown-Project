using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampScript : MonoBehaviour {

    public GameObject Player;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            SwampMenuScript.SwampCollision = true;
        }
    }
}
