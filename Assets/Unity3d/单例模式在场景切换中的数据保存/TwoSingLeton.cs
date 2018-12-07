using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 在unity里面去实现单例
/// </summary>
public class TwoSingLeton : MonoBehaviour
{
    private static TwoSingLeton twoSing = null;
    public Tollgate_Data[] tollgate_Datas = new Tollgate_Data[10];
    public static GameObject obj;

    private void Start()
    {
        getInstance();
    }

    public static TwoSingLeton getInstance()
    {
        if (twoSing == null)
        {
            obj = new GameObject("Program Creat Object");
            twoSing = obj.AddComponent(typeof(TwoSingLeton)) as TwoSingLeton;
            twoSing.init();
            DontDestroyOnLoad(obj);
        }
        return twoSing;
    }

    void init()
    {
        for (int i = 0; i < tollgate_Datas.Length; i++)
        {
            tollgate_Datas[i].index = 2;
            tollgate_Datas[i].playerHealth = 2;
        }
    }
}
