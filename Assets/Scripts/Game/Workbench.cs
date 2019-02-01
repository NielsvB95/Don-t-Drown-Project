using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour {

    // Use this for initialization
    public GameObject Player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player)
        {
            CraftingMenu.WorkBench = true;
        }
    }
}
