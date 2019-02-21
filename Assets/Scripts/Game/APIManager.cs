using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;

/*
 * This class is responsible for handling connections with the API.
 * For example:
 * the login functions,
 * retrieving the data from the player (stats, inventory),
 * and data for the quiz.
*/
public class APIManager : MonoBehaviour
{
    private QuizData[] allQuizData = GameData.AllQuizData;
    private UserData userData;

    // Start is called before the first frame update
    void Start()
    {
        LoadQuizData();
        Login();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadQuizData()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://dontdrown.nl/api/vraag");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        string JSONToParse = "{\"allQuizData\":[{\"vragen\": " + jsonResponse + "}]}";
        GameData loadedData = JsonUtility.FromJson<GameData>(JSONToParse);
        allQuizData = loadedData.allQuizData;
        GameData.AllQuizData = allQuizData;
    }

    public void Login()
    {
        string url = "http://dontdrown.nl/api/auth/login/";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        userData = JsonUtility.FromJson<UserData>(jsonResponse);
        Debug.Log(userData.SaveId);
    }

}
