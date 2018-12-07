using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientEnter : MonoBehaviour
 {

    [ContextMenu("单例模式")]
    public void Click()
	{
		GameManger_zy.GetInstance.init();
	}
}
