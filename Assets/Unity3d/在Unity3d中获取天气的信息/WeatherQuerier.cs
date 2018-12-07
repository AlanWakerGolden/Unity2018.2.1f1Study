using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Compression;
using System.IO;

public class WeatherQuerier : MonoBehaviour {


    private IEnumerator Start()
    {
        WWW www = new WWW("http://wthrcdn.etouch.cn/weather_mini?city=广州");
        yield return www;
        string result = Decompress(www.bytes);
        Debug.Log(result);
    }

    /// <summary>
    /// 解压缩
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    string Decompress(byte[] bytes)
    {
        var lengthBuffer = new byte[4];
        //将bytes数组（bytes.Length-4位置）复制到lengthBuffer（0号位置），长度为4
        System.Array.Copy(bytes,bytes.Length-4,lengthBuffer,0,4);
        int uncompressedSize = System.BitConverter.ToInt32(lengthBuffer, 0);
        var buffer = new byte[uncompressedSize];
        using (var ms = new MemoryStream(bytes))
        {
            using (var gzip = new GZipStream(ms, CompressionMode.Decompress))
            {
                gzip.Read(buffer,0,uncompressedSize);
            }
        }
        return System.Text.Encoding.UTF8.GetString(buffer);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
