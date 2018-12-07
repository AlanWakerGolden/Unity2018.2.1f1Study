using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 定义一个基础接口1（所有的银行账户必须继承该接口）
/// </summary>
public interface IBankAccount
{
    void PayIn(decimal account);  //存钱函数
    bool Withdraw(decimal account); //取钱函数
    decimal Balance { get; }  //账户余额
	
}
