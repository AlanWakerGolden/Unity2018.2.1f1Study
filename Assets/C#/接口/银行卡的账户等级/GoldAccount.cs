using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这是一名高级的银行用户
/// </summary>
public class GoldAccount : MonoBehaviour, IBankAccount, IBankAdvancedAccount
{
    private decimal balance;
    public GoldAccount(string name)
    {
        Debug.Log(name+" 您好！");
    }
    public decimal Balance
    {
        get
        {
            return balance;
        }
    }

    /// <summary>
    /// 金卡用户，在交易开始之前必须要实现这个接口
    /// </summary>
    public void DealStartTip()
    {
        Debug.Log("交易开始，请注意周围环境");
    }

    public void DealStopTip()
    {
        Debug.Log("交易结束，请带好你的贵重物品，欢迎下次光临。");
    }

    public void PayIn(decimal account)
    {
        balance = balance + account;
    }

    public bool Withdraw(decimal amount)
    {
        if (balance > amount)
        {
            balance = balance - amount;
            return true;
        }
        Debug.Log("余额不足");
        return false;
    }

    public override string ToString()
    {
        return string.Format("Saver Bank balance:", balance);
    }

}
