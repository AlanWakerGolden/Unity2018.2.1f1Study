using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这是一个抽象类，在unity中可能会有异常
/// </summary>
 abstract public class OLAOBase : MonoBehaviour
{
    /// <summary>
    /// 方法的重载，在同一各类中，函数的签名不同
    /// </summary>
    /// <param name="i">函数签名：参数的类型和参数的数量</param>
    public void FunOverLoad(int i)
    {
        Debug.Log("我是方法1，我只有一个参数int类型："+i);
    }
    //仅有返回类型的不同无法重载，只能依据参数的数量和参数的类型进行重载
    //private void FunOverLoad()
    //{
       // 会报错

    //}
    public void FunOverLoad(int i,int j)
    {
        Debug.Log("我是方法2，我只有两个个参数全int类型：" + i+" "+j);
    }
    public void FunOverLoad(string i)
    {
        Debug.Log("我是方法3，我只有一个参数string类型：" + "<color=red>"+i+"</Color>");
    }

    /// <summary>
    /// 在子类中对这个类进行重写，这是一个虚方法，就算在本类里面也可以调用,但不可为静态Static
    /// </summary>
    /// <param name="str"></param>
    protected virtual void FunOverride(string str)
    {      
        Debug.Log("这里是重写方法的基类，在自己的类里也可以被调用"+"<color=green>"+str+"</color>",gameObject);
    }

    /// <summary>
    /// 这是一个抽象方法，没有自己的实体，所以必须在派生类来重写，且这个类必须是抽象类
    /// </summary>
    abstract protected void FunabsOverride();
    

    private void Start()
    {
        FunOverLoad(3);
        FunOverLoad(1, 2);
        FunOverLoad("重载");

        FunOverride("我是基类");
    }
}
