using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * This class is responsible for handling connections with the API.
 * For example:
 * the login functions,
 * retrieving the data from the player (stats, inventory),
 * and data for the quiz.
*/
public class APIManager : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;

    private QuizData[] allQuizData = GameData.AllQuizData;
    private UserData userData;

    // Start is called before the first frame update
    void Start()
    {
        LoadQuizData();
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
        string username = usernameField.text;
        string password = passwordField.text;
        string url = "http://dontdrown.nl/api/auth/login/" + username + "/" + password;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if(response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            userData = JsonUtility.FromJson<UserData>(jsonResponse);
            Debug.Log(userData.SaveId);

            url = "http://dontdrown.nl/api/save/" + userData.SaveId.ToString();
            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            jsonResponse = reader.ReadToEnd();
            Debug.Log(jsonResponse);
            SceneManager.LoadScene("Game");
        }
    }

}
