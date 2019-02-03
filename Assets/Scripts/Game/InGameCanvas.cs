using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InGameCanvas : MonoBehaviour {

    public void OpenInventoryMenu()
    {
        InventoryMenu.InventoryCheck = true;
    }

    void Start()
    {
        StartCoroutine(PostRequest("http:///www.yoururl.com"));
    }

    IEnumerator PostRequest(string url)
    {
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
}
