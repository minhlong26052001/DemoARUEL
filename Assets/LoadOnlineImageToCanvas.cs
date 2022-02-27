using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadOnlineImageToCanvas : MonoBehaviour
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
        else{
			Texture2D webTexture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture2D;
			Sprite webSprite = SpriteFromTexture2D(webTexture);
			gameObject.GetComponent<Image>().sprite = webSprite;
		}
    }
	
	Sprite SpriteFromTexture2D(Texture2D texture) {
		return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
	}
	
    
}