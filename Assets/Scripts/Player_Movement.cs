using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour {

    public float moveSpeed = 2f;
    public static bool hasAxe = false;
    public static bool hasPickaxe = false;
    public static bool hasPitchfork = false;
    // Use this for initialization
    void Start () {
        Debug.Log(SceneManager.GetSceneByName(SceneManager.GetActiveScene().ToString()));
        if (SceneManager.GetActiveScene().ToString().Equals("Game"))
        {
            Datamanager dataManager = new Datamanager();
            transform.position = dataManager.LoadPlayer();
            Debug.Log("DataManager is called");
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f)); 
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3( 0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
        }
    }
}
