using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通过银行的账户级别来了解一下接口
/// </summary>
public class ShowFun : MonoBehaviour
{
    [ContextMenu("Run")]
    private void ShowMain()
    {
        SaverAccount sa = new SaverAccount();
        sa.PayIn(100000000);
        sa.Withdraw(200);
        Debug.Log("账户余额："+sa.Balance);

        GoldAccount ga = new GoldAccount("张亿");
        ga.DealStartTip();
        ga.PayIn(100);
        ga.Withdraw(10000000000);
        Debug.Log("账户余额： "+ga.Balance);
        ga.DealStopTip();
    }

}
