using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZY;

public class ClientTest : MonoBehaviour {

    private string testMsg = "Test Message";
    public Text content;

	// Use this for initialization
	void Start ()
    {
        // ZyMessage.Start();
      
    }
    [ContextMenu("Send")]
    public void test()
    {
        MobileClient._instance.Print("笑了");
        //ZyMessage.RemotePrint("我笑了");
    }
    [ContextMenu("Receive")]
    void Test2()
    {
        ZyMessage.ReceiveMessage();           
    }

    private void Update()
    {
        //if (!string.IsNullOrEmpty(ZyMessage.m_message))
        //{
        //    content.text +="\n"+ZyMessage.m_message;
        //    ZyMessage.Clear();
        //}
    }
    private void OnDestroy()
    {
        //ZyMessage.Shutdown();
    }
}
