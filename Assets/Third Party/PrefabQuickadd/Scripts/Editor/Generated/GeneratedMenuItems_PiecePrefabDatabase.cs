// AUTO-GENERATED CLASS. DO NOT EDIT.
// This is an automatically generated script, any changes made will be overwritten.
using UnityEngine;
using UnityEditor;

public static class GeneratedMenuItems_PiecePrefabDatabase
{
    [MenuItem("GameObject/Add Prefab/Piece/prefab_tile", false, priority = -1)]
    private static void MenuItem0()
    {
        var asset = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Project/Prefabs/prefab_tile.prefab", typeof(GameObject));
        var go = (GameObject)PrefabUtility.InstantiatePrefab(asset);
        go.transform.SetParent(Selection.activeTransform);
        go.transform.localPosition = asset.transform.position;
        Selection.activeGameObject = go;
    }

}
