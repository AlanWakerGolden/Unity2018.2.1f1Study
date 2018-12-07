using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoleConfig))]
public class RoleConfigEditor : Editor
{
    RoleConfig mScript;
    private void OnEnable()
    {
        mScript = target as RoleConfig;
        if (mScript.mInfo == null)
        {
            mScript.mInfo = new RoleInfo();
        }
    }

}
