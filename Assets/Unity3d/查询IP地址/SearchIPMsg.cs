using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

using System.Text;

public class SearchIPMsg 
{
    public static string GetData(string token,string ip=null,string datatype="txt")
    {
        if (string.IsNullOrEmpty(ip))
        {
           // ip= HttpContext.Current.Request.UserHostAddress;
        }
        string url = string.Format("http://api.ip138.com/query/?ip={0}&datatype={1}&token={2}", ip, datatype, token);
        using (WebClient client = new WebClient())
        {
            client.Encoding = Encoding.UTF8;
            return client.DownloadString(url);
        }
    }
}
