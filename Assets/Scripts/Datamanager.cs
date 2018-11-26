using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datamanager : MonoBehaviour {

    /// <summary>Static reference to the instance of our DataManager</summary>
    public static Datamanager instance;
    public GameObject Player;
    public Vector3 playerPosition;
       
    private static string playerPositionKeyY = "PLAYER_POSITIONY";
    private static string playerPositionKeyX = "PLAYER_POSITIONX";

    /// <summary>Saves playerName, playerScore and 
    /// playerHealth to the PlayerPrefs file.</summary>
    public void Save()
    {
        playerPosition = Player.transform.position;
        // Set the values to the PlayerPrefs file using their corresponding keys.
        PlayerPrefs.SetFloat(playerPositionKeyY, playerPosition.y);
        PlayerPrefs.SetFloat(playerPositionKeyX, playerPosition.x);
        // Manually save the PlayerPrefs file to disk, in case we experience a crash
        PlayerPrefs.Save();
        Debug.Log(playerPosition);
    }

    /// <summary>Saves playerName, playerScore and playerHealth 
    // from the PlayerPrefs file.</summary>
    public Vector3 Load()
    {
        if (PlayerPrefs.HasKey(playerPositionKeyY) && PlayerPrefs.HasKey(playerPositionKeyX))
        {
            // load playerPosition from the PlayerPrefs file.
            playerPosition = new Vector3(PlayerPrefs.GetFloat(playerPositionKeyX), PlayerPrefs.GetFloat(playerPositionKeyY), 0);
            return playerPosition;
        }
        return new Vector3(0, 0, 0);
    }
}
