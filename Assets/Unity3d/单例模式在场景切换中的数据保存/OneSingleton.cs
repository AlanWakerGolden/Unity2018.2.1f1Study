using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Tollgate_Data
{
    public int index;
    public int playerHealth;
}

/// <summary>
/// 纯C#单例模式
/// </summary>
public class OneSingleton
{
    private static OneSingleton oneSingleton = null;
    public Tollgate_Data[] _Datas = new Tollgate_Data[10];

    public static OneSingleton getInstance()
    {
        if (oneSingleton == null)
        {
            oneSingleton = new OneSingleton();
            oneSingleton.init();
        }
        return oneSingleton;
    }

    public void init()
    {
        for (int i = 0; i < _Datas.Length; i++)
        {
            _Datas[i].index = 1;
            _Datas[i].playerHealth = 1;
        }
    }
}
