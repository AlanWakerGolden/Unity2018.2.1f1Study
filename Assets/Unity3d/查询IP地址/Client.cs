using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Client : MonoBehaviour
{
    [ContextMenu("查询")]
    public void Search()
    {     
        string data= SearchIPMsg.GetData("a0f66f3b17841da6e0167abbfe7bf110","192.168.0.1" );
        Debug.Log("<color=red>"+data+"</color>");
    }
	
}
