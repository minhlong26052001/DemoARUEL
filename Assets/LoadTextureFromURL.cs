using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
 
public class LoadTextureFromURL : MonoBehaviour
{
 
    public string TextureURL = "";
 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownloadImage(TextureURL));
    }
 
    // Update is called once per frame
    void Update()
    {
         
    }
 
    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            this.gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}