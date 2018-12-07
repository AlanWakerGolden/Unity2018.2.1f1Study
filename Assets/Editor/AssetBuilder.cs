using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetBuilder : Editor
{
    [MenuItem("Assets/Build All Asset Bundles")]
    static void BuildAll()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles/Android", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
	
}
