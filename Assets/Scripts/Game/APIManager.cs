using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using System.Text;

/*
 * This class is responsible for handling connections with the API.
 * For example:
 * the login functions,
 * retrieving the data from the player (stats, inventory),
 * and data for the quiz.
*/
public class APIManager : MonoBehaviour

{
    private string URL = "http://dontdrown.nl/api/save/2017";
    private string json = "\"{\\\"Level\\\": 1, \\\"LevelUp\\\": \\\"true\\\", \\\"Inventory\\\": {\\\"Wood\\\":"+Inventory.Wood+"}}\"";

    public InputField usernameField;
    public InputField passwordField;

    private QuizData[] allQuizData = GameData.AllQuizData;
    private UserData userData;

    // Start is called before the first frame update
    void Start()
    {
        LoadQuizData();
        StartCoroutine(Put(URL,json));
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
            JToken token = JToken.Parse(jsonResponse);
            JObject json = JObject.Parse((string)token);
            SceneManager.LoadScene("Game");
        }
    }

    public IEnumerator Put(string url, string json)
    {
        byte[] myData = Encoding.UTF8.GetBytes(json);
        UnityWebRequest request = UnityWebRequest.Put(url, myData);
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Upload complete!");
        }
    }
}
