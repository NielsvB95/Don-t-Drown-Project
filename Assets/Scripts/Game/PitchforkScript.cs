using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchforkScript : MonoBehaviour
{

    public GameObject Player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            Player_Movement.hasPitchfork = true;
            Destroy(this.gameObject);
        }
    }
}
