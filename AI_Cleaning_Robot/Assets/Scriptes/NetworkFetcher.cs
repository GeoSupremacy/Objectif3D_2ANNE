using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using UnityEngine.Networking;

public class NetworkFetcher : MonoBehaviour
{
    public static event Action<Deal[]> Ondeals = null;
    // WaitForSeconds wait = new WaitForSeconds(2);
    // float time = 0;
    IEnumerator Start()
    {
        //yield return
        yield return StartCoroutine(GetDeals());
        // yield return StartCoroutine(PrepareLoading());
        // StartGame();
    }

    IEnumerator GetDeals()
    {

        UnityWebRequest _request = UnityWebRequest.Get(API.Deals);
        yield return _request.SendWebRequest();
        if (_request.result != UnityWebRequest.Result.Success)
            Debug.LogError("DOWNLOAD FAIL!");
        else
        {
            Deal[] _deals = JsonConvert.DeserializeObject<Deal[]>(_request.downloadHandler.text);
            Ondeals.Invoke(_deals);
        }

      
    }
    IEnumerator PrepareLoading()
    {
        /*
         *  
        Debug.Log("Enter");
        while(time <2)
        {
            time += Time.deltaTime;
            Debug.Log(time);
            yield return null;
        }
        time = 0;
        Debug.Log("Exit");
        ============================
        while (time < 2)
        {
            time += Time.deltaTime;
            Debug.Log("PrepareLoading");
            yield return null;
        }
        */
        yield return null;
    }
    IEnumerator DownloadImage()
    {
        UnityWebRequest _request = UnityWebRequestTexture.GetTexture(API.Deals);

        yield return _request.SendWebRequest();
        Texture2D _t = DownloadHandlerTexture.GetContent(_request); //N'est pas une texture
    }
}
