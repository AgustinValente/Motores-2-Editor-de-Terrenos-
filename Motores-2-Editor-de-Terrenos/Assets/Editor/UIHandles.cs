using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Random = UnityEngine.Random;

public class UIHandles : EditorWindow
{
    public NoiseSave load;
    public Plane ValueScript;
    private bool isShowing, activar;
    public string nameScript;


    [MenuItem("Custom Window/UI Handles")]
    private static void OnEnable()
    {
        UIHandles myeditor = (UIHandles)GetWindow(typeof(UIHandles));
        myeditor.Show();
    }
    private void OnFocus()
    {
        SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
        SceneView.onSceneGUIDelegate += this.OnSceneGUI;
    }

    
    private void OnSceneGUI(SceneView sceneView)
    {
        if (isShowing)
        {
            SceneView.RepaintAll();
            GUISceneShow();
        }

    }

    private void OnGUI()
    {
        ValueScript = GameObject.FindObjectOfType<Plane>();
        
        isShowing = EditorGUILayout.Toggle("Editar Terreno", isShowing);
      
    }

    private void Load()
    {
        ValueScript.height = load.height;
        ValueScript.width = load.width;
        ValueScript.scale = load.scale;
        ValueScript.offsetx = load.offsetx;
        ValueScript.offsety = load.offsety;
    }
    private void Save()
    {
        var scriptObj = ScriptableObjectUtillity.CreateAsset<NoiseSave>(nameScript);
        scriptObj.height = ValueScript.height;
        scriptObj.width = ValueScript.width;
        scriptObj.scale = ValueScript.scale;
        scriptObj.offsetx = ValueScript.offsetx;
        scriptObj.offsety = ValueScript.offsety;
    }
    private void GUISceneShow()
    {
        Handles.BeginGUI();

       var v = EditorWindow.GetWindow<SceneView>().camera.pixelRect;
        GUILayout.BeginArea(new Rect(20, 20, 250, 300));
        var rec = EditorGUILayout.BeginVertical();
        GUI.color = new Color32(255, 255, 255, 100);
        GUI.Box(rec, GUIContent.none);
        GUI.color = Color.white;

       EditorGUILayout.Space();
        nameScript = EditorGUILayout.TextField("Guardar Como: ", nameScript);
        if (GUILayout.Button("Guardar"))
        {
            Save();
        }


        EditorGUILayout.Space();
        load = EditorGUILayout.ObjectField("Cargar", load, typeof(NoiseSave), false) as NoiseSave;
        if (GUILayout.Button("Cargar"))
        {
            Load();
        }
        EditorGUILayout.Space();
        EditorGUILayout.EndVertical();
        GUILayout.EndArea();
        Handles.EndGUI();
    }

   

   

}
