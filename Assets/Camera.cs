using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public WebCamTexture cameraTexture;
    public string cameraName = "";
    private bool isPlay = false;
    // Use this for initialization  
    void Start()
    {
        StartCoroutine(Test());
    }

    // Update is called once per frame  
    void Update()
    {

    }

    IEnumerator Test()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            cameraName = devices[0].name;
            cameraTexture = new WebCamTexture(cameraName, 1280, 720, 30);
            cameraTexture.Play();
            isPlay = true;
        }
    }

    void OnGUI()
    {
        if (isPlay)
        {
            GUI.DrawTexture(new Rect(0, 0, 1280, 720), cameraTexture, ScaleMode.ScaleToFit);
        }
    }
}
