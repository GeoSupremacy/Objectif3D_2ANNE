using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Unity.VisualScripting;
using System.ComponentModel.Design;

public class NetworkFetcher : MonoBehaviour
{
    

    public static ListBook ListBook;


    private void Awake() =>InventoryUI.OnBook += ActionDeserialize;

    public void ActionDeserialize()
    {
        Debug.LogError("StartCoroutine!");
       StartCoroutine(GetVolume());
        
    }
    IEnumerator GetVolume()
    {

        UnityWebRequest _request = UnityWebRequest.Get(API.Volume);
        yield return _request.SendWebRequest();
        if (_request.result != UnityWebRequest.Result.Success)
            Debug.LogError("DOWNLOAD FAIL!");
        else
        {
            //Debug.LogError("DeserializeObject");
            ListBook = JsonConvert.DeserializeObject<ListBook>(_request.downloadHandler.text);
           
        }
    }
    IEnumerator DownloadImage()
    {
        Debug.LogError("DownloadImage!");
        UnityWebRequest _request = UnityWebRequestTexture.GetTexture(API.Volume);

        yield return _request.SendWebRequest();
        Texture2D _t = DownloadHandlerTexture.GetContent(_request); //N'est pas une texture
    }
}//