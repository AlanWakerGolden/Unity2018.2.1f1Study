using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnumeratorStudy : MonoBehaviour {

     public int num =0;
	IEnumerator Start()
	{
		for(int i=0;i<100;i++)
		{
			Debug.Log("Number:"+i);
		    yield return null; //下一帧再来执行后续代码
			//yield return 0或其他数字，表示同上
		}
		//yield break;   //直接结束该协程的后续操作
		yield return new WaitUntil(()=>num==5); //直到程序num==5时。。。
		Debug.Log("结束");
		yield return null;
	} 
		
	
}
