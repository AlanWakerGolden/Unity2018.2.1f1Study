
//以下代码为zy原创，以后会越加完善，他用请标明
using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.SceneManagement;

/// <summary> 
/// 用于自动保存unity里Hierarchy界面下的对象，以免unity bug
/// </summary>
public class AutoSave :EditorWindow {

    private int intervalScene;  //时间间隔：分
    private DateTime lastSaveTimeScene = DateTime.Now;
    
    [MenuItem("Window/自动保存")]
    static void Init()
    {
        GetWindow(typeof(AutoSave));
       // n = DateTime.Now.Second;
    }
    
    private void Update()
    {
        if (DateTime.Now.Minute >= (lastSaveTimeScene.Minute + intervalScene) || DateTime.Now.Minute == 59 && DateTime.Now.Second == 59)
        {
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
            lastSaveTimeScene = DateTime.Now;      
           
        } //当当前时间大于上一次保存场景时的时间与时间间隔之和时，保存一次场景
          //或者当时间的分秒为59：59时保存一次
      
    }

    private void OnGUI()
    {
        //绘制将要保存的场景名字
        GUILayout.Space(10);
        GUI.skin.label.fontSize = 12;
        GUI.skin.label.alignment = TextAnchor.UpperLeft;
        GUILayout.Label("当前场景: " + EditorSceneManager.GetActiveScene().name);

        // second = EditorGUILayout.Slider("时间间隔", second, 30, 300);
        intervalScene= EditorGUILayout.IntSlider("时间", intervalScene, 2, 10);
  
        GUILayout.Space(10);
        GUI.skin.label.fontSize = 12;
        GUI.skin.label.alignment = TextAnchor.UpperLeft;
        GUILayout.Label("上一次保存的时间: " + lastSaveTimeScene);
    }

}
