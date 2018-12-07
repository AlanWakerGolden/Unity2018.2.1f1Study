using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraCatchPlay : MonoBehaviour {

    public RawImage rawImage;
    public Button openCamera;
    public Button shutdownCamera;

    private WebCamTexture webCamTexture;
	// Use this for initialization
	void Start ()
    {
        StartCoroutine("CallWebCam");

        openCamera.onClick.AddListener(OpenCamera);
        shutdownCamera.onClick.AddListener(ShutdownCamera);
	}

    IEnumerator CallWebCam()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);  //请求外部摄像头权限

        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            webCamTexture = new WebCamTexture();
            WebCamDevice[] devices = WebCamTexture.devices;
            webCamTexture.deviceName = devices[0].name;

            rawImage.texture = webCamTexture;   

        }
    }


    void OpenCamera()
    {
        webCamTexture.Play();
    }

    void ShutdownCamera()
    {
        webCamTexture.Stop();
    }
}
