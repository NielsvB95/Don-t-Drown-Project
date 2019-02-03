using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class InGameCanvas : MonoBehaviour {

    public void OpenInventoryMenu()
    {
        InventoryMenu.InventoryCheck = true;
    }

    void Start()
    {
        //StartCoroutine(PostRequest("http:///dontdrown.nl/api/save/1"));
    }
    /*
    IEnumerator PostRequest(string url)
    {
        var request = new UnityWebRequest("http://dontdrown.nl/api/save/1", "POST");
        Inventory str = new Inventory();
        //str["pageNumber"] = 0;
        string jsonStr = str.ToJson();
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStr);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        string getByte = Encoding.ASCII.GetString(bodyRaw);
        Debug.Log(getByte);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Authorization", tokenBulu);
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code:" + request.downloadHandler.text);

        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");
        form.AddField("Game Name", "Mario Kart");

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
    */
}
