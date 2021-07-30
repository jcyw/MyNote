using System.Numerics;
using System.Diagnostics;
using System.ComponentModel.Design;
using System.Data;
using UnityEditor;
using UnityEngine;

public class MenuTest : EditorWindow {

    [MenuItem("GameObject/MyMenu/Print-Name",false,12)]
    private static void PrintObjName(MenuCommand command) {
        GameObject obj = command.context as GameObject;
        Debug.LogError("selected obj name is " + obj.name);
    }

    [MenuItem("GameObject/MyMenu/print-path _b",false,13)]
    static void PrintObjPath(MenuCommand command) {
        var target = Selection.activeGameObject;
        var transform = target.transform;
        var result = "";
        while(transform){
            if (result == ""){
                result = transform.name;
            }else{
                result = transform.name + "/" + result;
            }
            transform = transform.parent;
        }
        Debug.LogError("selected obj path is " + result);
    }

    [MenumItem("MyTools/Playing")]
    static void Playing(){
        if (EditorApplication.isPlaying)
            EditorApplication.isPlaying = false;
        else
            EditorApplication.isPlaying = true;
    }
    Vector2Int p1;
    bool showBtn = true;
    Vector2 scrollPosition;
    string longString = "this is a long-string";
    string str;
    [MenuItem("MyTools/MyWindow")]
    static void MyWindow(){
        EditorWindow win = EditorWindow.GetWindow(typeof(MunuTest),true,"myWindow");
        win.minSize = new Vector2(800,800);
    }
    void OnGUI() {
        if (GUILayout.Button("testBtn",GUILayout.Width(100),GUILaout.Height(20))){
            Debug.LogError("click testBtn");
        }
        Rect r = scrollPosition;
        GUILayout.Lable("positon :" + r.x + "x" + r.y);
        GUILayout.BeginHorzontal("box");
        p1 = EditorGUILayout.Vector2IntField("set the position:",p1);
        if (showBtn){
            if(GUILayout.Button("accept new positon",GUILayout.Width(200))){
                r.x = p1.x;
                r.y = p1.y;

                scrollPosition = r;
            }
        }
        GUILayout.EndHorizontal();

        scrollPosition = GUILayout.BeginScrollView(
            scrollPosition,GUILayout.Width(200),GUILayout.Height(200)
        );
        GUILayout.Lable(longString);
        GUILayout.EndScrollView();
        if (GUILayout.Button("Clear",GUILayout.Width(200))){
            longString = "";
        }
        
        GUILayout.BeginHorzontal("input");
        str = EditorGUILayout.DelayedTextField("please input content:",str);
        if (GUILayout.Button("Add",GUILayout.Width(100),GUILayout.Height(20))){
            longString += ("\n" + str);
        }
        GUILayout.EndHorizontal();
    }
}