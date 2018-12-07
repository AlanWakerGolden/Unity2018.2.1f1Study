using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// #19使用位移运算符获取汉字的编码
/// </summary>
public class GetCharaCode : MonoBehaviour
{
    [Tooltip("得到一个汉字字符")]
    public char chr;
    [Tooltip("显示汉字的编码")]
    public string txt_Num;
    [ContextMenu("执行")]
    public void GetCode()
    {
        try
        {
            byte[] gb2312 = Encoding.GetEncoding("gb2312").GetBytes(new char[] { chr });
            Debug.Log(gb2312.Length);
            int n = gb2312[0] << 8;
            n += gb2312[1];
            txt_Num = n.ToString("X8");
        }
        catch (Exception)
        {
            Debug.LogError("请输入汉字字符");
        }

    }


}
