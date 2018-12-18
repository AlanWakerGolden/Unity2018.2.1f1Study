using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NumType
{
   _hp,_mp,_exp
}

public class BaseUnit 
{
    private float _hp;
    private float _mp;
    private float _exp;
    public string _name;
	

    public float hp
    {
        get
        {
            return _hp;
        }
    }

    public float mp
    {
        get
        {
            return _mp;
        }
    }

    public float exp
    {
        get
        {
            return _exp;
        }
    }

    public BaseUnit(string name)
    {
        _name = name;
        _hp = 100;
        _mp = 100;
        _exp = 0;
    }

    public delegate void changNum(BaseUnit source, float amount, NumType numType);
    public event changNum OnNumChange;

    public void ChangNum(float amount, NumType numType)
    {
        switch (numType)
        {
            case NumType._hp:
                _hp += amount;
                break;
            case NumType._mp:
                _mp += amount;
                break;
            case NumType._exp:
                _exp += amount;
                break;
        }
        if (OnNumChange != null)
        {
            OnNumChange(this,amount,numType);
        }
    }


}
