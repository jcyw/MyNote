// 在Unity编辑器中创建预制体并设置材料
using UnityEngine;
using UnityEditor;

public class PrefabCreator : EditorWindow
{
    GameObject prefabObject;
    Material material;

    [MenuItem("Window/Prefab Creator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<PrefabCreator>("Prefab Creator");
    }

    void OnGUI()
    {
        GUILayout.Label("Create Prefab with Material", EditorStyles.boldLabel);

        prefabObject = EditorGUILayout.ObjectField("Prefab Object:", prefabObject, typeof(GameObject), true) as GameObject;
        material = EditorGUILayout.ObjectField("Material:", material, typeof(Material), true) as Material;

        if (GUILayout.Button("Create Prefab"))
        {
            CreateNewPrefab();
        }
    }

    void CreateNewPrefab()
    {
        if (prefabObject == null)
        {
            Debug.LogError("PrefabObject is null.");
            return;
        }

        string localPath = "Assets/NewPrefab.prefab";
        PrefabUtility.SaveAsPrefabAssetAndConnect(prefabObject, localPath, InteractionMode.UserAction);

        GameObject newPrefab = AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)) as GameObject;

        Renderer[] renderers = newPrefab.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            renderer.sharedMaterial = material;
        }
    }
}
