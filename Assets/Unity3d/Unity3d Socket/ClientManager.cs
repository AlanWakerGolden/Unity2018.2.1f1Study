using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine.UI;


public class ClientManager : MonoBehaviour {

    /// <summary>
    /// 服务器计算机所在的ip和端口
    /// </summary>
   public const string m_ipAddress = "192.168.43.175";
    //public const string m_ipAddress = "47.106.113.36";  //公网地址
    public const int m_port = 2233;

    private Socket m_clientSocket;
    private Thread m_reCeiveThread;
    private byte[] m_msgData = new byte[1024];//消息数据容器
    private string m_message;//保存消息，因为在线程里面不允许直接操作Unity组件

    public InputField m_input;
    public Text m_label;

    // Use this for initialization
    void Start()
    {
        m_label.text = "";
        ConnentToServer();

        //开启一个线程专门用于接收消息
        m_reCeiveThread = new Thread(ReceiveMessage);
        m_reCeiveThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(m_message))
        {
            m_label.text += "\n" + m_message;
            Debug.Log("m_message:" + m_message);
            m_message = "";
        }
    }

    /// <summary>
    /// 自定义的函数，连接到服务器
    /// </summary>
    public void ConnentToServer()
    {
        m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //跟服务器建立连接
        Debug.Log("开始连接服务器");
        //clientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.108"), 2345));
        m_clientSocket.Connect(new IPEndPoint(IPAddress.Parse(m_ipAddress), m_port));
        SendMessageToServer("哈哈");
        Debug.Log("连接服务器执行完毕");
    }

    /// <summary>
    /// 向服务器发送消息
    /// </summary>
    /// <param name="message"></param>
    void SendMessageToServer(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        m_clientSocket.Send(data);
    }

    /// <summary>
    /// 点击发送按钮事件
    /// </summary>
    public void OnClickBtnSend()
    {
        string message = m_input.text;
        if (string.IsNullOrEmpty(message))
        {
            Debug.LogWarning("发送消息不能为空");
            return;
        }
        SendMessageToServer(message);
        m_input.text = "";
    }

    void ReceiveMessage()
    {
        while (true)
        {
            //在接受消息之前判断Socket是否连接
            if (m_clientSocket.Connected == false)
                break;
            int length = m_clientSocket.Receive(m_msgData);//这里会等待接收消息，程序暂停，只有接收到消息后才会继续执行
            m_message = Encoding.UTF8.GetString(m_msgData, 0, length);
        }
    }

    void OnDestroy()
    {
        //禁用Socket的发送和接收功能
        m_clientSocket.Shutdown(SocketShutdown.Both);
        //关闭Socket
        m_clientSocket.Close();
    }
}
