using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZY;

///北大招生题：已知ab=cd，则a+b+c+d有可能等于多少？
public class Test1_abcdAdd : MonoBehaviour
{
    int a, b, c, d;

    [ContextMenuItem("继续","StartFun")]
    [SerializeField]
    bool IsExe = true;

    int[] array;
    List<int[]> num;

    public void StartFun()
    {
        zDebug.Log(".................",ZY.Color.blue);
        while (IsExe)
        {
            a = Random.Range(1, 401);
            b = Random.Range(1, 401);
            c = Random.Range(1, 401);
            d = Random.Range(1, 401);

            if (a * b == c * d)
            {
                int re = a + b + c + d;
               // zDebug.Log("四个数之和为：" + re);
               
                if (re == 201 || re == 301 || re == 401)
                {
                    zDebug.Log("这就是可能的答案：" + re);
                    zDebug.Log("此时的各项值为：a="+a+",b="+b+",c="+c+",d="+d);
                    array = new int[4] { a, b, c, d };
                    if (num.Count != 10)
                    {
                        foreach (int[] o in num)
                        {
                            if (array == o)
                            {
                                continue;
                            }
                            else { num.Add(array);continue; }
                        }
                    }
                    else
                    {
                        zDebug.Log("打印10个可能的数");
                        foreach (int[] o in num)
                        {
                            zDebug.Log(o.GetValue(0, 3));
                        }
                        break;
                    }
                    continue;                  
                }
            }
            else continue;
        }    
    }
}
