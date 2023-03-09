using UnityEngine;
using UnityEditor;
// 查询材质球引用
public class FindMaterialReferences : EditorWindow
{
    // 声明一个材质球变量
    Material materialToFind;

    [MenuItem("Tools/Find Material References")]
    // public static void ShowWindow()
    // {
    //     // 创建窗口
    //     GetWindow<FindMaterialReferences>("Find Material References");
    // }

    // void OnGUI()
    // {
    //     GUILayout.Label("Find References to Material", EditorStyles.boldLabel);

    //     // 添加材质球字段到窗口
    //     materialToFind = (Material)EditorGUILayout.ObjectField("Material To Find", materialToFind, typeof(Material), true);

    //     if (GUILayout.Button("Find"))
    //     {
    //         // 查找场景和资产中引用此材质球的所有游戏对象和组件
    //         Object[] objects = Resources.FindObjectsOfTypeAll(typeof(GameObject));
    //         foreach (GameObject go in objects)
    //         {
    //             Renderer[] renderers = go.GetComponentsInChildren<Renderer>(true);
    //             foreach (Renderer renderer in renderers)
    //             {
    //                 if (renderer.sharedMaterial == materialToFind)
    //                 {
    //                     Debug.Log(go.name + " uses " + materialToFind.name);
    //                 }
    //             }
    //         }
    //     }
    // }
    static void Init()
    {
        GetWindow(typeof(FindMaterialReferences));
    }
    void OnGUI()
    {
        materialToFind = (Material)EditorGUILayout.ObjectField("Material" , typeof(Material), true);
        if(GUILayout.Button("Find use"))
        {
            if(materialToFind == null)
            {
                Debug.log("material is not selected!");
                return
            }
            string[] guids = AssetDatabase.FindAssets("t:Prefab");
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                GameObject prefab = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject)) as GameObject;
                Renderer[] renders = prefab.GetComponentsInChildren<Renderer>();
                foreach (Renderer renderer in renders)
                {
                    for(Material mat in renderer.sharedMaterials)
                    {
                        if(mat == material)
                        {
                            Debug.log(String.Format("{0} use {1}", prefab.name , mat.name))
                        }
                    }
                }
            }
        }
    }
}
