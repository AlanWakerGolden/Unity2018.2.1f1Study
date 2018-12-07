using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这是一名普通的银行用户
/// </summary>
public class SaverAccount : MonoBehaviour,IBankAccount
{
   private decimal balance;

    public void PayIn(decimal account)
    {
        balance = balance + account;
    }

    public bool Withdraw(decimal amount)
    {
        if (balance >= amount)
        {
            balance = balance - amount;
            return true;
        }
        Debug.Log("余额不足");
        return false;       
    }

    public decimal Balance
    {
        get
        {
            return balance;
        }
    }
    public override string ToString()
    {
        return string.Format("Saver Bank balance:",balance);
    }
}
