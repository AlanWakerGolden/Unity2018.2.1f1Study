using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对数组进行增删改查
/// </summary>
public class ArrayOperation
{
    /// <summary>
    /// 在特定的位置插入一个元素,index指的是数组的下标位置
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    /// <param name="array">源数组</param>
    /// <param name="value">要插入的元素</param>
    /// <param name="index">插入的位置</param>
    /// <returns></returns>
    public static T[] InsertAt<T>(T[] array, T value, int index)
    {
        //数组在插入元素之前的元素位置不用变化
        //把插入独立出来，之后的操作和之前的是一样的
        //需要注意index的理解
        T[] temp = array;                //创建的临时数组
        array = new T[array.Length+1];   //需要增加一个元素，所以需要扩容一个单位
        Array.Copy(temp,0,array,0,index);//将index前面的元素拷贝进array(https://docs.microsoft.com/zh-cn/dotnet/api/system.array.copy?view=netframework-4.7.2)
        array[index] = value;            //将元素插入
        Array.Copy(temp,index,array,index+1,temp.Length-index);  //将temp中剩下的数组复制到array中

        return array;
    }

    /// <summary>
    /// 在特定的位置插入一个元素数组，index指的是数组的下标位置
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    /// <param name="array">源数组</param>
    /// <param name="value">待插入数组</param>
    /// <param name="index">插入的位置</param>
    /// <returns></returns>
    public static T[] InsertAt<T>(T[] array, T[] value, int index)
    {
        T[] temp = array;
        array = new T[array.Length + value.Length];
        Array.Copy(temp,0,array,0,index);
        Array.Copy(value,0,array,index,value.Length);
        Array.Copy(temp,index,array,index+value.Length,temp.Length-index);
        return array;
    }

    /// <summary>
    /// 在数组的首位置插入一个值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static T[] PushFist<T>(T[] array,T value)
    {
        return InsertAt(array, value, 0);
    }
   
    /// <summary>
    /// 在数组的末位置插入一个值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static T[] PushLast<T>(T[] array,T value)
    {
        return InsertAt(array,value,array.Length);
    }

    /// <summary>
    /// 移除数组从start开始之后的count个元素
    /// </summary>
    /// <typeparam name="T">泛型</typeparam>
    /// <param name="array">源数组</param>
    /// <param name="start">开始移除的位置</param>
    /// <param name="count">需要移除的长度</param>
    /// <returns></returns>
    public static T[] RemoveAt<T>(T[] array,int start,int count)
    {
        T[] temp = array;
        array = new T[array.Length-count>=0?array.Length-count:0];
        Array.Copy(temp,array,start);
        int index = start + count;
        if (index < temp.Length)
        {
            Array.Copy(temp,index,array,start,temp.Length-index);
        }
        return array;
    }

    /// <summary>
    /// 移除一个元素，index表示数组的下标,不是第几个元素，0表示第一个元素
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array">源数组</param>
    /// <param name="index">待移除的数组的位置</param>
    /// <returns></returns>
    public static T[] RemoveAt<T>(T[] array, int index)
    {
        return RemoveAt(array, index, 1);
    }

    /// <summary>
    /// 移除数组从start开始到end结束的数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array">源数组</param>
    /// <param name="start">开始索引</param>
    /// <param name="end">结束索引</param>
    /// <returns></returns>
    public static T[] RemoveRange<T>(T[] array,int start,int end)
    {
        return RemoveAt(array,start,end-start+1);
    }

    /// <summary>
    /// 移除第一个元素
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array">源数组</param>
    /// <returns></returns>
    public static T[] Pop<T>(T[] array)
    {
        return RemoveAt(array, 0, 1);
    }

    /// <summary>
    /// 从数组开始位置到之后的count的元素进行移除
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array">源数组</param>
    /// <param name="count">需要移除的长度</param>
    /// <returns></returns>
    public static T[] Pop<T>(T[] array, int count)
    {
        return RemoveAt(array,0,count);
    }

    /// <summary>
    /// 移除最后一位元素
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    /// <returns></returns>
    public static T[] PopLast<T>(T[] array)
    {
        return RemoveAt(array,array.Length-1,1);
    }

    /// <summary>
    /// 移除最后的count个元素
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array">源数组</param>
    /// <param name="count">需要移除的长度</param>
    /// <returns></returns>
    public static T[] PopLast<T>(T[] array, int count)
    {
        return RemoveAt(array, array.Length - count, count);
    }

    /// <summary>
    /// 找到这个元素并且移除这个元素
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array">源数组</param>
    /// <param name="value">元素值</param>
    /// <returns></returns>
    public static T[] FindRemove<T>(T[] array,T value)
    {
        int index = Array.IndexOf<T>(array,value);
        if (index >= 0)
            return RemoveAt(array,index);
        return array;
    }

    /// <summary>
    /// 找到这个元素并且移除所有value元素
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array">源数组</param>
    /// <param name="value">将移除的值</param>
    /// <returns></returns>
    public static T[] FindRemoveAll<T>(T[] array, T value)
    {
        int index = 0;
        do
        {
            index = Array.IndexOf(array, value);
            if (index >= 0)
                array = RemoveAt(array, index);
        }
        while (index >= 0 && array.Length > 0);
        return array;


    }

    /// <summary>
    /// 将orgin及其之后的连续count-1个元素往后移动decalage个位置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array">源数组</param>
    /// <param name="orgin">起始位置</param>
    /// <param name="count">移动元素的数量</param>
    /// <param name="decalage">移动多少位</param>
    /// <returns></returns>
    public static T[] Move<T>(T[] array,int orgin,int count,int decalage)
    {
        if (array == null) return null;
        T[] result = (T[])array.Clone();
        //限定orgin，不能使其超出了源数组的长度
        orgin = orgin < 0 ? 0 : (orgin >= result.Length ? result.Length - 1 : orgin);
        count = count < 0 ? 0 : (orgin + count >= result.Length ? result.Length - orgin - 1 : count);
        //decalage = orgin + decalage < 0 ? -orgin : ();

        int absDec = Math.Abs(decalage);
        T[] items = new T[count];
        T[] dec = new T[absDec];

        Array.Copy(array,orgin,items,0,count);
        Array.Copy(array, orgin + (decalage >= 0 ? count:decalage),dec,0,absDec);
        //Array.Copy();

        return result;
    }

    /// <summary>
    /// 将indice位置的元素向后移动一个单位
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array">源数组</param>
    /// <param name="indice">需要移动的元素位置</param>
    /// <returns></returns>
    public static T[] MoveRight<T>(T[] array,int indice)
    {
        return Move(array,indice,1,1);
    }



}
