using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Random = UnityEngine.Random;

public class UIHandles : EditorWindow
{
    public NoiseSave load;
    public Noise noiseScript;
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
        noiseScript = GameObject.FindObjectOfType<Noise>();
        
        isShowing = EditorGUILayout.Toggle("Editar Terreno", isShowing);
        

        

    }

    private void Load()
    {

        noiseScript.height = load.height;
        noiseScript.width = load.width;
        noiseScript.scale = load.scale;
        noiseScript.offsetx = load.offsetx;
        noiseScript.offsety = load.offsety;
    }

    private void Save()
    {
        var scriptObj = ScriptableObjectUtillity.CreateAsset<NoiseSave>(nameScript);
        scriptObj.height = noiseScript.height;
        scriptObj.width = noiseScript.width;
        scriptObj.scale = noiseScript.scale;
        scriptObj.offsetx = noiseScript.offsetx;
        scriptObj.offsety = noiseScript.offsety;
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
