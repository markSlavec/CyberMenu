using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CVSLoader : MonoBehaviour
{
    private bool _debug = true;
    private const string url = "https://docs.google.com/spreadsheets/d/*/export?format=csv";
    private string _actualUrl;

    private void Start()
    {
        
    }
    public void DownloadTable(string sheetId, Action <string> onSheetLoadedAction)
    {
        //string actualUrl = url.Replace("*", sheetId); 
        _actualUrl = sheetId;
        StartCoroutine(DownloadRawCvsTable(_actualUrl, onSheetLoadedAction));
    }



    private IEnumerator DownloadRawCvsTable(string actualUrl, Action<string> _callback)
    {
        while (!Caching.ready)
            yield return null;
        using (UnityWebRequest request = UnityWebRequest.Get(actualUrl))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError ||
                request.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                if (_debug)
                {
                    Debug.Log("Successful download");
                    //Debug.Log(request.downloadHandler.text);
                }

                _callback(request.downloadHandler.text);
            }

        }
        yield return null;
    }
}
