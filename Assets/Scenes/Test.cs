using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    [ContextMenu("执行")]
    public void test1()
    {

        Debug.Log(Fun1.F(5));
    }
}
