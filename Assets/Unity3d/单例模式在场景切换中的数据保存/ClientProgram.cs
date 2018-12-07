using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientProgram : MonoBehaviour
{
    private GameObject button;
    private GameObject button2;
    private void Start()
    {
        button = GameObject.Find("Canvas/Button");
        button2 = GameObject.Find("Canvas/Button2");
      
        button.GetComponent<Button>().onClick.AddListener(Show);    
        button2.GetComponent<Button>().onClick.AddListener(Switch);
    }

    private void Show()
    {       
        Debug.Log(OneSingleton.getInstance()._Datas[3].index);
        Debug.Log(OneSingleton.getInstance()._Datas[3].playerHealth);

        Debug.Log("<color=red>" + TwoSingLeton.getInstance().tollgate_Datas[2].index + "</color>");

        Debug.Log("<color=green>" + ThreeSingLeton.getInstance().tollgate_Datas[3].index + "</color>");
    }

    private void Switch()
    {
        string sceneName;
        char[] sceneNameChar;
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        //Debug.Log(sceneName);
        sceneNameChar = sceneName.ToCharArray();
        switch (sceneNameChar[2])
        {
            case '1':
                UnityEngine.SceneManagement.SceneManager.LoadScene("场景2");
                break;
            case '2':
                UnityEngine.SceneManagement.SceneManager.LoadScene("场景3");
                break;
            case '3':
                UnityEngine.SceneManagement.SceneManager.LoadScene("场景1");
                break;

        }
    }
}
