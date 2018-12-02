﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datamanager : MonoBehaviour {

    /// <summary>Static reference to the instance of our DataManager</summary>
    public static Datamanager instance;
    public GameObject Player;
    public GameObject Camera;
    public Vector3 playerPosition;
    public Vector3 cameraPosition;
    
    private static string playerPositionKeyY = "PLAYER_POSITIONY";
    private static string playerPositionKeyX = "PLAYER_POSITIONX";
    private static string cameraPositionKeyY = "CAMERA_POSITIONY";
    private static string cameraPositionKeyX = "CAMERA_POSITIONX";
    private static string cameraPositionKeyZ = "CAMERA_POSITIONZ";

    /// <summary>Saves playerName, playerScore and 
    /// playerHealth to the PlayerPrefs file.</summary>
    public void SavePlayerPosition()
    {
        playerPosition = Player.transform.position;
        // Set the values to the PlayerPrefs file using their corresponding keys.
        PlayerPrefs.SetFloat(playerPositionKeyY, playerPosition.y);
        PlayerPrefs.SetFloat(playerPositionKeyX, playerPosition.x);

        // Manually save the PlayerPrefs file to disk, in case we experience a crash
        PlayerPrefs.Save();
        Debug.Log(playerPosition);
    }

    public void SaveCameraPostion()
    {
        PlayerPrefs.SetFloat(cameraPositionKeyX, cameraPosition.x);
        PlayerPrefs.SetFloat(cameraPositionKeyY, cameraPosition.y);
        PlayerPrefs.SetFloat(cameraPositionKeyZ, cameraPosition.z);

        PlayerPrefs.Save();
        Debug.Log(cameraPosition);
    }

    /// <summary>Saves playerName, playerScore and playerHealth 
    // from the PlayerPrefs file.</summary>
    public Vector3 LoadPlayer()
    {
        if (PlayerPrefs.HasKey(playerPositionKeyY) && PlayerPrefs.HasKey(playerPositionKeyX))
        {
            playerPosition = new Vector3(PlayerPrefs.GetFloat(playerPositionKeyX), PlayerPrefs.GetFloat(playerPositionKeyY), 0);
            // load playerPosition from the PlayerPrefs file.
            return playerPosition;
        }
        return playerPosition = new Vector3(0, 0, 0);
    }

    public Vector3 LoadCameraPosition()
    {
        if (PlayerPrefs.HasKey(cameraPositionKeyX) && PlayerPrefs.HasKey(cameraPositionKeyY) && PlayerPrefs.HasKey(cameraPositionKeyZ))
        {
            cameraPosition = new Vector3(PlayerPrefs.GetFloat(cameraPositionKeyX), PlayerPrefs.GetFloat(cameraPositionKeyY), PlayerPrefs.GetFloat(cameraPositionKeyZ));
            return cameraPosition;
        }
        return cameraPosition = new Vector3(0, 0, -1);
    }
}
