using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSocket : MonoBehaviour {

    [ContextMenu("测试")]
    void Zy()
    {
        MobileClient._instance.Print("AlanWaker是最帅的男人");
    }

}
