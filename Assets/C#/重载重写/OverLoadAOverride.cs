using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLoadAOverride : OLAOBase
{
    /// <summary>
    /// 必须实现的抽象方法，因为继承了抽象类
    /// </summary>
    protected override void FunabsOverride()
    {
        Debug.Log("我是从抽象类中实现的抽象方法，我在子类中，而且很开心");
    }

    protected override void FunOverride(string str)
    {
        //base.FunOverride("张亿");
        Debug.Log("我是派生类，我被重写了" + str);
    }
    new private void FunOverLoad(string str)
    {
        Debug.Log("这是我自己的方法,为了不被隐藏，所以需要New");
    }
    private void Start()
    {

        FunOverride("笑一笑");
        FunabsOverride();
    }
}
