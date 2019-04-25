using Newtonsoft.Json.Linq;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private SerializableUserData userData;
    private SerializableSaveData saveData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadQuizData(int playerLevel)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://dontdrown.nl/api/vraag/");
        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://dontdrown.nl/api/vraag/game/" + playerLevel.ToString());
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
                SaveData.ConstitutionLevel = saveData.ConstitutionLevel;
                SaveData.IntelligenceLevel = saveData.IntelligenceLevel;
                SaveData.StrengthLevel = saveData.StrengthLevel;
                SaveData.WisdomLevel = saveData.WisdomLevel;
                SaveData.FlowerSpawn = saveData.FlowerSpawn;
                SaveData.GemstoneSpawn = saveData.GemstoneSpawn;
                SaveData.MushroomSpawn = saveData.MushroomSpawn;

                CheckLevelup();

                //Load questions and answers
                LoadQuizData(SaveData.Level);

                //Set inventory items with data from savegame
                Inventory.Wood = saveData.Inventory.Wood;
                Inventory.Grass = saveData.Inventory.Grass;
                Inventory.Stone = saveData.Inventory.Stone;
                Inventory.Pebble = saveData.Inventory.Pebble;
                Inventory.Iron = saveData.Inventory.Iron;
                Inventory.Straw = saveData.Inventory.Straw;
                Inventory.Stick = saveData.Inventory.Stick;
                Inventory.Flower = saveData.Inventory.Flower;
                Inventory.Mushroom = saveData.Inventory.Mushroom;
                Inventory.Gemstone = saveData.Inventory.Gemstone;
                Inventory.ConstitutionPotion = saveData.Inventory.ConstitutionPotion;
                Inventory.IntelligencePotion = saveData.Inventory.IntelligencePotion;
                Inventory.StrengthPotion = saveData.Inventory.StrengthPotion;
                Inventory.WisdomPotion = saveData.Inventory.WisdomPotion;
                Inventory.Axe = saveData.Inventory.Axe;
                Inventory.Pitchfork = saveData.Inventory.Pitchfork;
                Inventory.Pickaxe = saveData.Inventory.Pickaxe;

                SaveGame();

                SceneManager.LoadScene("Game");
            }
        }
    }

    public void SaveGame()
    {
        StartCoroutine(Put());
    }

    public IEnumerator Put()
    {
        string json = MakeInventory();
        string URL = "http://dontdrown.nl/api/save/" + UserData.SaveId.ToString();
        byte[] myData = Encoding.UTF8.GetBytes(json);
        UnityWebRequest request = UnityWebRequest.Put(URL, myData);
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

    public string MakeInventory()
    {
        int Wood = Inventory.Wood;
        int Grass = Inventory.Grass;
        int Stone = Inventory.Stone;
        int Pebble = Inventory.Pebble;
        int Iron = Inventory.Iron;
        int Straw = Inventory.Straw;
        int Stick = Inventory.Stick;
        int Flower = Inventory.Flower;
        int Mushroom = Inventory.Mushroom;
        int Gemstone = Inventory.Gemstone;
        int ConstitutionPotion = Inventory.ConstitutionPotion;
        int IntelligencePotion = Inventory.IntelligencePotion;
        int StrengthPotion = Inventory.StrengthPotion;
        int WisdomPotion = Inventory.WisdomPotion;
        bool Axe = Inventory.Axe;
        bool Pitchfork = Inventory.Pitchfork;
        bool Pickaxe = Inventory.Pickaxe;

        string json = "\"{\\\"Level\\\": " + SaveData.Level +
            ", \\\"LevelUp\\\":\\\"" + SaveData.LevelUp +
            "\\\", \\\"Request\\\":\\\"" + SaveData.Request +
            "\\\", \\\"ConstitutionLevel\\\": " + SaveData.ConstitutionLevel +
            ", \\\"IntelligenceLevel\\\": " + SaveData.IntelligenceLevel +
            ", \\\"StrengthLevel\\\": " + SaveData.StrengthLevel +
            ", \\\"WisdomLevel\\\": " + SaveData.WisdomLevel +
            ", \\\"FlowerSpawn\\\": " + SaveData.FlowerSpawn +
            ", \\\"GemstoneSpawn\\\": " + SaveData.GemstoneSpawn +
            ", \\\"MushroomSpawn\\\": " + SaveData.MushroomSpawn +
            ", \\\"Inventory\\\": {" +
                "\\\"Wood\\\":" + Wood + "," +
                "\\\"Grass\\\":" + Grass + "," +
                "\\\"Stone\\\":" + Stone + "," +
                "\\\"Pebble\\\":" + Pebble + "," +
                "\\\"Iron\\\":" + Iron + "," +
                "\\\"Straw\\\":" + Straw + "," +
                "\\\"Stick\\\":" + Stick + "," +
                "\\\"Flower\\\":" + Flower + "," +
                "\\\"Mushroom\\\":" + Mushroom + "," +
                "\\\"Gemstone\\\":" + Gemstone + "," +
                "\\\"ConstitutionPotion\\\":" + ConstitutionPotion + "," +
                "\\\"IntelligencePotion\\\":" + IntelligencePotion + "," +
                "\\\"StrengthPotion\\\":" + StrengthPotion + "," +
                "\\\"WisdomPotion\\\":" + WisdomPotion + "," +
                "\\\"Axe\\\":\\\"" + Axe + "\\\"," +
                "\\\"Pitchfork\\\":\\\"" + Pitchfork + "\\\"," +
                "\\\"Pickaxe\\\":\\\"" + Pickaxe +
                "\\\"}}\"";
        return json;
    }

    public void CheckLevelup()
    {
        if(SaveData.LevelUp == true)
        {
            SaveData.LevelUp = false;
            SaveData.Level += 1;
        }
    }
}
