﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	// Use this for initialization
	public void StartGame () {
        SceneManager.LoadScene("Game");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
