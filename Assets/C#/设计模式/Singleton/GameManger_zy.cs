using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManger_zy 
{
    private static GameManger_zy instance;

	public static GameManger_zy GetInstance
	{

		get
		{
			if(instance==null)
			{
				instance=Activator.CreateInstance<GameManger_zy>();
			}
			return instance;
		}
	}

	public void init()
	{
		Debug.Log("Initialized");
	}
	
}
