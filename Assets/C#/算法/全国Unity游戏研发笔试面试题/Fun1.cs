using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fun1
{
    public static long F(int n)
    {
        if (n == 1)
        {      
            return 1;
        }
        else if (n == 2)
        {           
            return 2;
        }
        else if (n >= 3)
        {           
            return F(n - 1) + F(n - 2);
        }
        else return -1;

    } 
	
}
