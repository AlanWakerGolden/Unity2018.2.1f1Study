using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInformation : MonoBehaviour {

    BaseUnit hero;
	// Use this for initialization
	void Start ()
    {
        hero = new BaseUnit("MIKI");
        hero.OnNumChange += Hero_OnNumChang;
	}

    private void Hero_OnNumChang(BaseUnit source, float amount, NumType numtype)
    {
        print(source._name+"__"+numtype.ToString()+"  "+"增加了:"+amount);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 50), "加血"))
        {
            hero.ChangNum(100, NumType._hp);
        }
        if (GUI.Button(new Rect(0, 50, 100, 50), "补蓝"))
        {
            hero.ChangNum(50, NumType._mp);
        }
        if (GUI.Button(new Rect(0, 100, 100, 50), "经验"))
        {
            hero.ChangNum(88,NumType._exp);
        }
    }
}
