using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FolderSharp : MonoBehaviour {
	[SerializeField]
	private string url;
	private string name;

    [ContextMenu("创建文件夹")]
	private void FolderCreat () 
	{
		// if (Directory.Exists (url) == false) 
		// {
		// 	Directory.CreateDirectory (url);
		// }
		StartCoroutine("FoderDeal");

	}

	IEnumerator FoderDeal()
	{
     for(int i=0;i<100;i++)
	 {
		 name="'\'"+i+"zy";
		 Directory.Delete(url+name); //删除文件夹
		// Directory.CreateDirectory (url+name); //创建文件夹
      yield return null;
	 }

	}

}