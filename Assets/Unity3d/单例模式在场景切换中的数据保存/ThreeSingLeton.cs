using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeSingLeton : MonoBehaviour
{
    private static ThreeSingLeton threeSing = null;
    public Tollgate_Data[] tollgate_Datas = new Tollgate_Data[10];

    private void Awake()
    {
        if (threeSing == null)
        {
            threeSing = this;
            threeSing.init();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static ThreeSingLeton getInstance()
    {
        return threeSing;
    }

    void init()
    {
        for (int i = 0; i < tollgate_Datas.Length; i++)
        {
            tollgate_Datas[i].index = 3;
            tollgate_Datas[i].playerHealth = 3;
        }
    }
}
