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
    private SerializableUserData userData;
    private SerializableSaveData saveData;

    // Start is called before the first frame update
    void Start()
    {
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
        //Load questions and answers
        LoadQuizData();

        //Retrieve user data from API
        string username = usernameField.text;
        string password = passwordField.text;
        string url = "http://dontdrown.nl/api/auth/login/" + username + "/" + password;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode.Equals(HttpStatusCode.OK))
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            userData = JsonUtility.FromJson<SerializableUserData>(jsonResponse);

            //Set UserData with retrieved data
            UserData.Id = userData.Id;
            UserData.Username = userData.Username;
            UserData.RolId = userData.RolId;
            UserData.Rol = userData.Rol;
            UserData.SaveId = userData.SaveId;
            UserData.Classname = userData.Classname;

            //Use save id to retrieve save data from API
            url = "http://dontdrown.nl/api/save/" + userData.SaveId.ToString();
            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                reader = new StreamReader(response.GetResponseStream());
                jsonResponse = reader.ReadToEnd();
                JToken token = JToken.Parse(jsonResponse);
                JObject json = JObject.Parse((string)token);
                saveData = json.ToObject<SerializableSaveData>();

                //Set save data with retrieved data
                SaveData.Level = saveData.Level;
                SaveData.LevelUp = saveData.LevelUp;
                SaveData.Request = saveData.Request;

                //Set inventory items with data from savegame
                Inventory.Wood = saveData.Inventory.Wood;
                Inventory.Clay = saveData.Inventory.Clay;
                Inventory.Stone = saveData.Inventory.Stone;
                Inventory.Pebble = saveData.Inventory.Pebble;
                Inventory.Iron = saveData.Inventory.Iron;
                Inventory.Straw = saveData.Inventory.Straw;
                Inventory.Stick = saveData.Inventory.Stick;
                Inventory.Flower = saveData.Inventory.Flower;
                Inventory.Mushroom = saveData.Inventory.Mushroom;
                Inventory.Gemstone = saveData.Inventory.Gemstone;
                Inventory.WisdomPotion = saveData.Inventory.WisdomPotion;
                Inventory.Axe = saveData.Inventory.Axe;
                Inventory.Pitchfork = saveData.Inventory.Pitchfork;
                Inventory.Pickaxe = saveData.Inventory.Pickaxe;

                SceneManager.LoadScene("Game");
            }
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
