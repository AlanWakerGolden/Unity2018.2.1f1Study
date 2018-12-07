using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using ZY;

[HelpURL("https://docs.unity3d.com/ScriptReference/HelpURLAttribute.html")]
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider), typeof(Animation))]
public class AttributeTest : MonoBehaviour
{
    [Space(20)]
    [TextArea]
    public string Attribute;

    [ContextMenuItem("开始", "PrintColorMsg")]
    [ContextMenuItem("初始化", "Init")]
    public int num = 1;

    public int souStart = 0;
    public int newStart = 0;
    public int[] int1 = new int[5] { 0, 1, 2, 3, 4 };
    public int[] int2 = new int[5] { 2, 2, 2, 2, 2 };


    private void Start()
    {
       
    }

    [ContextMenu("Execute")]
    void PrintColorMsg()
    {
        zDebug.Log("在运行时会自动执行这个方法");
        //Array.Copy(int1, souStart, int2, newStart, num);
        //int1 = ArrayTools.InsertAt(int1,88,num);
        //int1 = ArrayTools.InsertAt(int1,int2 ,num);
        //int1 = ArrayTools.PushFist(int1, 88);
        //int1 = ArrayTools.RemoveAt(int1,1);
        //int1 = ArrayOperation.RemoveAt(int1,0,3);
        int1 = ArrOpera.CreateRandom(10,0,100);
        //Type type = typeof(ArrayTools);
        // zDebug.Log("当前成员名称: "+type.Name+", "+"获取类的全部名称: "+type.FullName+", "+"该类的命名空间: "+type.Namespace+", "+type.Assembly+"  "+type.Module+"  "+type.MemberType+"  "+type.ReflectedType+"  "+type.UnderlyingSystemType+"  "+type.TypeInitializer+"结束");
        Assembly assembly = Assembly.GetExecutingAssembly();
        zDebug.Log(assembly.FullName);
        foreach (var item in assembly.GetTypes())
        {
            zDebug.Log("类:"+item.Name);
        }
    }
    void Init()
    {
         num = 1;
         souStart = 0;
         newStart = 0;
         int1 = new int[5] { 0, 1, 2, 3, 4 };
         int2 = new int[5] {2,2,2,2,2 };
        
     }
}
