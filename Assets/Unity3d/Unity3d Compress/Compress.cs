using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ZY;
using System.Text;
using System.IO;

public class Compress : MonoBehaviour
{
    string strText= "ASCII码：一个英文字母（不分大小写）占一个字节的空间，一个中文汉字占两个字节的空间。一个二进制数字序列，在计算机中作为一个数字单元，一般为8位二进制数，换算为十进制。最小值-128，最大值127。如一个ASCII码就是一个字节。UTF-8编码：一个英文字符等于一个字节，一个中文（含繁体）等于三个字节。中文标点占三个字节，英文标点占一个字节Unicode编码：一个英文等于两个字节，一个中文（含繁体）等于两个字节。中文标点占两个字节，英文标点占两个字节";
    string array="";
    StreamWriter writer;
    StreamReader reader;
    [ContextMenu("生产")]
    void Fun()
    {
        FileInfo file = new FileInfo(Application.dataPath + "/BinaryText.txt");
        if (file.Exists)
        {
            file.Delete();
        }
        byte[] arrByteFile = Encoding.UTF8.GetBytes(strText);
        Debug.Log(arrByteFile.Length);
        Debug.Log(strText.Length);
        //foreach (byte a in arrByteFile)
        //{
        //    Debug.Log(a);
        //}
        foreach (int a in arrByteFile)
        {
            zDebug.Log(a);
            string binary = Convert.ToString(a, 2);
           
            array += binary;
        }
     
        WriteIntoTxt(array);
    }
    /// <summary>
    /// 把所有的数据写入文本中
    /// </summary>
    /// <param name="message">消息</param>
    public void WriteIntoTxt(string message)
    {
        FileInfo file = new FileInfo(Application.dataPath + "/斗破zip.txt");
        if (!file.Exists)
        {
            writer = file.CreateText();
        }
        else
        {
            writer = file.AppendText();
        }
        writer.WriteLine(message);
        writer.Flush();
        writer.Dispose();
        writer.Close();
    }

    [ContextMenu("Reader")]
    void Reader()
    {     
        Debug.Log(ReaderIntoTxt());
        string termianal = ReaderIntoTxt();
    }
    

    /// <summary>
    /// 读
    /// </summary>
    /// <param name="message">消息</param>
    public string ReaderIntoTxt()
    {
        FileInfo file = new FileInfo(Application.dataPath + "/斗破.txt");
        if (file.Exists)
        {
          reader = file.OpenText();        
        }
        else
        {
            Debug.Log("没有文件");
        }
        string outStr=reader.ReadLine();
        Override(outStr);
        reader.Dispose();
        reader.Close();
        return outStr;
    }

    /// <summary>
    /// 重写
    /// </summary>
    public void Override(string Text)
    {
        byte[] arrByteFile = Encoding.UTF8.GetBytes(Text);
        foreach (int a in arrByteFile)
        {          
            string binary = Convert.ToString(a, 2); //转为二进制
            array += binary;
        }

        WriteIntoTxt(array);
    }
}
