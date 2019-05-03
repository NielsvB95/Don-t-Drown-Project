using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour {

    public Animator animator;
    public float moveSpeed = 2f;
    public static bool hasAxe = false;
    public static bool hasPickaxe = false;
    public static bool hasPitchfork = false;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        Time.timeScale = 1f;
        if ( sceneName == "Game")
        {
            Datamanager dataManager = new Datamanager();
            transform.position = dataManager.LoadPlayer();
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

        if (Input.GetAxisRaw("Horizontal") > 0.0f)
        {
            spriteRenderer.flipX = false;
        }

        if (Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            spriteRenderer.flipX = true;
        }

        if(Mathf.Abs(Input.GetAxisRaw("Vertical")) > Mathf.Abs(Input.GetAxisRaw("Horizontal")))
        {
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Vertical")));
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        }
    }
}
