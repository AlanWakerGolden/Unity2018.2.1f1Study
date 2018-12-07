using UnityEngine;
using UnityEngine.UI;
using ZY;

/// <summary>
/// 这个脚本一定要挂在一个组件上，同时ZY.dll记得引用
/// 可以想象成Debug.log(),只不过你需要MobileClient._instance.Print(内容);这样来使用
/// 公司的网络可能无法使用
/// </summary>
public class MobileClient : MonoBehaviour {

    public Text content; //展示消息的文本
    public static MobileClient _instance;  //当前的实例

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else return;

    }
    
    void Start ()
    {      
        ZyMessage.Start();  //启动客户端
        ZyMessage.ReceiveMessage();  //开启消息的接收
    }
    [ContextMenu("hh")] //这个方法供给单例去外部使用
    public void Print(object obj)
    {
        ZyMessage.RemotePrint(obj);    //打印到移动端，类比Debug.log(obj);
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ZyMessage.Shutdown();
            Application.Quit();
        }

        if (!string.IsNullOrEmpty(ZyMessage.m_message))
        {
            content.text += "\n" + ZyMessage.m_message;
            ZyMessage.Clear();  //显示出来后，将消息清空一次
        }       
    }

    private void OnDestroy()
    {
        ZyMessage.Shutdown();
    }
}
