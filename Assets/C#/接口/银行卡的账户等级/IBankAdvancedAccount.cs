using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对于银行的一些高级用户需要实现的接口
/// </summary>
public interface IBankAdvancedAccount
{
    void DealStartTip(); //交易开始提示
    void DealStopTip(); //交易结束提示
}
