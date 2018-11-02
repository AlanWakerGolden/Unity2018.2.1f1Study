using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AddChild : ScriptableObject
{
    [MenuItem("GameObject/+Add Child")]
    static void MenuAddChild()
    {
        Transform[] transform = Selection.GetTransforms(SelectionMode.TopLevel|SelectionMode.OnlyUserModifiable);
        foreach (Transform trans in transform)
        {
            GameObject newChild = new GameObject("_null");
            newChild.transform.parent = trans;
            newChild.transform.localPosition = Vector3.zero;
        }
    }

    [MenuItem("GameObject/-Clear Child")]
    static void MenuClearChild()
    {
        Transform[] transform = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.OnlyUserModifiable);
        foreach (Transform trans in transform)
        {
            if (trans.GetChild(0).name == "_null")
            {
                DestroyImmediate(trans.GetChild(0).gameObject);
            }              
        }
    }	
}
