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
    //public static NetworkFetcher Instance;

    public static event Action<Deals[]> Ondeals = null;
   
   public IEnumerator Start()
    {
      
         yield return StartCoroutine(GetDeals());
    }

        

    IEnumerator GetDeals()
    {

        UnityWebRequest _request = UnityWebRequest.Get(API.Deals);
        yield return _request.SendWebRequest();
        if (_request.result != UnityWebRequest.Result.Success)
            Debug.LogError("DOWNLOAD FAIL!");
        else
        {
            Debug.LogError("DeserializeObject");
            Deals[] _deals = JsonConvert.DeserializeObject<Deals[]>(_request.downloadHandler.text);
            Ondeals.Invoke(_deals);
        }
    }
    IEnumerator DownloadImage()
    {
        UnityWebRequest _request = UnityWebRequestTexture.GetTexture(API.Deals);

        yield return _request.SendWebRequest();
        Texture2D _t = DownloadHandlerTexture.GetContent(_request); //N'est pas une texture
    }
}//