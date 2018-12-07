using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

/**先搭建了一个http服务器Ngix（免费开源）
 * 详情见《计算机视觉增强现实应用程序开发》111页
 * 这里是一个下载类
 * **/

public class DownLoder : MonoBehaviour {

    private GameObject btn;
    public RawImage rawImage;
    WWW www;

	// Use this for initialization
	void Start ()
    {
        btn = GameObject.Find("Canvas/Button");
        btn.GetComponent<Button>().onClick.AddListener(DownloadImage);
	}

    private void DownloadImage()
    {
        StartCoroutine(Download());
    }

    IEnumerator Download()
    {
        www = new WWW("http://192.168.5.150:8000/app/arcode/register");
      
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("DownLoad error" + www.error);
        }
        else
        {

            rawImage.texture = www.texture;
            Texture2D texture2D = www.texture;
            byte[] bytes = texture2D.EncodeToPNG();
            File.WriteAllBytes(Application.dataPath + "/Resources/picture.png", bytes);

        }

    }

}
