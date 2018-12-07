using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 使用异或运算符对数字进行简单的加密
/// </summary>
public class AddKey : MonoBehaviour
{
    [Tooltip("编码的规则")]
    public int code = 123;
    [ContextMenuItem("加密","AddKeyF")]
    [ContextMenuItem("解密","ReleaseKey")]
    [Tooltip("待加密的数字")]
    public int num;
    [Tooltip("加密后的数字")]
    public int newNum;

    void AddKeyF()
    {
        newNum = code ^ num;
    }

    void ReleaseKey()
    {
        newNum = newNum ^ code;
    }
}
