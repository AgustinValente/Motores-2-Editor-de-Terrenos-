using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class TerrainEditor : EditorWindow
{
    public NoiseSave load;
    public Plane noiseScript;
    private bool isShowing, activar;
    public string nameScript;

    //Shaders
    Material _material;

    bool _seePreview1, _seePreview2, _seePreview3, _seePreview4;
    Texture2D texture1, texture2, texture3, texture4;
    private Texture2D _preview, _preview2, _preview3, _preview4;

    Texture2D normal1, normal2, normal3, normal4;
    bool _seeNormal1, _seeNormal2, _seeNormal3, _seeNormal4;
    private Texture2D _Normalpreview, _Normalpreview2, _Normalpreview3, _Normalpreview4;

    float tilling1, tilling2, tilling3, tilling4;

    private Vector2 _scrollPosition;

    //Objects
    GameObject _object;
    Ray mousePosition;
    RaycastHit hit;

    [ExecuteAlways]
    [MenuItem("Custom Window/Terrain Editor")]
    private static void OnEnable()
    {
        TerrainEditor myeditor = (TerrainEditor)GetWindow(typeof(TerrainEditor));
        myeditor.Show();
    }

    private void OnGUI()
    {
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, false, true);
        Shader();

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        noiseScript = GameObject.FindObjectOfType<Plane>();
        isShowing = EditorGUILayout.Toggle("Save Data", isShowing);
        if (isShowing)
            GUISceneShow();

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (GUILayout.Button("Object Editor"))
            PrefabsEditor.OpenWindow();

       // GameObjectSpawn();

        EditorGUILayout.EndScrollView();
       


    }

  /*  private void OnSceneGUI()
    {
         mousePosition = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
    }*/
  
    void Shader()
    {
        EditorGUILayout.LabelField("Material :");
        //Material _material = (Material)Resources.Load("TerrainProof", typeof(Material));
        _material = (Material)EditorGUILayout.ObjectField(_material, typeof(Material),false);
        EditorGUILayout.HelpBox("Usar el material TerrainProof", MessageType.Info);
        if (_material != null)
        {
            EditorGUILayout.Space();
            Texture1();

            EditorGUILayout.Space();
            Texture2();

            EditorGUILayout.Space();
            Texture3();

            EditorGUILayout.Space();
            Texture4();
        }
    }

    void Texture1()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        texture1 = (Texture2D)EditorGUILayout.ObjectField(texture1, typeof(Texture2D), false);
        _material.SetTexture("_Texture1", texture1);

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        if(_seeNormal1)
        {
            normal1 = (Texture2D)EditorGUILayout.ObjectField(normal1, typeof(Texture2D), false);
            _material.SetTexture("_Normal1", normal1);
        }
        else
        {
            normal1 = null;
            _material.SetTexture("_Normal1", null);
        }

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        _seePreview1 = EditorGUILayout.Toggle("See Preview:", _seePreview1);
        _seeNormal1 = EditorGUILayout.Toggle("Use Normal:", _seeNormal1);

        GUILayout.EndHorizontal();

        tilling1 = EditorGUILayout.Slider(tilling1, 1, 10);
        _material.SetFloat("_Tilling1", tilling1);

        if (_seePreview1)
            Preview1();

    }
    void Preview1()
    {
        GUILayout.BeginHorizontal();
        if (texture1 != null)
        {
            var prevState = _preview;
            _preview = AssetPreview.GetAssetPreview(texture1);
            if (_preview != null)
            {
                if (prevState == null)
                    Repaint();
                GUI.DrawTexture(GUILayoutUtility.GetRect(100, 100, 100, 100), _preview, ScaleMode.ScaleToFit);
            }
        }
      

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (normal1 != null)
        {
            var prevStateN = _Normalpreview;
            _Normalpreview = AssetPreview.GetAssetPreview(normal1);
            if (_Normalpreview != null)
            {
                if (prevStateN == null)
                    Repaint();
                GUI.DrawTexture(GUILayoutUtility.GetRect(100, 100, 100, 100), _Normalpreview, ScaleMode.ScaleToFit);
            }
        }
           
        GUILayout.EndHorizontal();
    }

    void Texture2()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        texture2 = (Texture2D)EditorGUILayout.ObjectField(texture2, typeof(Texture2D), false);
        _material.SetTexture("_Texture2", texture2);

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        if (_seeNormal2)
        {
            normal2 = (Texture2D)EditorGUILayout.ObjectField(normal2, typeof(Texture2D), false);
            _material.SetTexture("_Normal2", normal2);
        }
        else
        {
            normal2 = null;
            _material.SetTexture("_Normal2", null);
        }

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        _seePreview2 = EditorGUILayout.Toggle("See Preview:", _seePreview2);
        _seeNormal2 = EditorGUILayout.Toggle("Use Normal:", _seeNormal2);

        GUILayout.EndHorizontal();

        tilling2 = EditorGUILayout.Slider(tilling2, 1, 10);
        _material.SetFloat("_Tilling2", tilling2);

        if (_seePreview2)
            Preview2();

    }
    void Preview2()
    {
        GUILayout.BeginHorizontal();
        if (texture2 != null)
        {
            var prevState = _preview2;
            _preview2 = AssetPreview.GetAssetPreview(texture2);
            if (_preview2 != null)
            {
                if (prevState == null)
                    Repaint();
                GUI.DrawTexture(GUILayoutUtility.GetRect(100, 100, 100, 100), _preview2, ScaleMode.ScaleToFit);
            }
        }


        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (normal2 != null)
        {
            var prevStateN = _Normalpreview2;
            _Normalpreview2 = AssetPreview.GetAssetPreview(normal2);
            if (_Normalpreview2 != null)
            {
                if (prevStateN == null)
                    Repaint();
                GUI.DrawTexture(GUILayoutUtility.GetRect(100, 100, 100, 100), _Normalpreview2, ScaleMode.ScaleToFit);
            }
        }

        GUILayout.EndHorizontal();
    }

    void Texture3()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        texture3 = (Texture2D)EditorGUILayout.ObjectField(texture3, typeof(Texture2D), false);
        _material.SetTexture("_Texture3", texture3);

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        if (_seeNormal3)
        {
            normal3 = (Texture2D)EditorGUILayout.ObjectField(normal3, typeof(Texture2D), false);
            _material.SetTexture("_Normal3", normal3);
        }
        else
        {
            normal3 = null;
            _material.SetTexture("_Normal3", null);
        }

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        _seePreview3 = EditorGUILayout.Toggle("See Preview:", _seePreview3);
        _seeNormal3 = EditorGUILayout.Toggle("Use Normal:", _seeNormal3);

        GUILayout.EndHorizontal();

        tilling3 = EditorGUILayout.Slider(tilling3, 1, 10);
        _material.SetFloat("_Tilling3", tilling3);

        if (_seePreview3)
            Preview3();

    }
    void Preview3()
    {
        GUILayout.BeginHorizontal();
        if (texture3 != null)
        {
            var prevState = _preview3;
            _preview3 = AssetPreview.GetAssetPreview(texture3);
            if (_preview3 != null)
            {
                if (prevState == null)
                    Repaint();
                GUI.DrawTexture(GUILayoutUtility.GetRect(100, 100, 100, 100), _preview3, ScaleMode.ScaleToFit);
            }
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (normal3 != null)
        {
            var prevStateN = _Normalpreview3;
            _Normalpreview3 = AssetPreview.GetAssetPreview(normal3);
            if (_Normalpreview3 != null)
            {
                if (prevStateN == null)
                    Repaint();
                GUI.DrawTexture(GUILayoutUtility.GetRect(100, 100, 100, 100), _Normalpreview3, ScaleMode.ScaleToFit);
            }
        }

        GUILayout.EndHorizontal();
    }

    void Texture4()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        texture4 = (Texture2D)EditorGUILayout.ObjectField(texture4, typeof(Texture2D), false);
        _material.SetTexture("_Texture4", texture4);

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        if (_seeNormal4)
        {
            normal4 = (Texture2D)EditorGUILayout.ObjectField(normal4, typeof(Texture2D), false);
            _material.SetTexture("_Normal4", normal4);
        }
        else
        {
            normal4 = null;
            _material.SetTexture("_Normal4", null);
        }

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        _seePreview4 = EditorGUILayout.Toggle("See Preview:", _seePreview4);
        _seeNormal4 = EditorGUILayout.Toggle("Use Normal:", _seeNormal4);

        GUILayout.EndHorizontal();

        tilling4 = EditorGUILayout.Slider(tilling4, 1, 10);
        _material.SetFloat("_Tilling4", tilling4);

        if (_seePreview4)
            Preview4();

    }
    void Preview4()
    {
        GUILayout.BeginHorizontal();
        if (texture4 != null)
        {
            var prevState = _preview4;
            _preview4 = AssetPreview.GetAssetPreview(texture4);
            if (_preview4 != null)
            {
                if (prevState == null)
                    Repaint();
                GUI.DrawTexture(GUILayoutUtility.GetRect(100, 100, 100, 100), _preview4, ScaleMode.ScaleToFit);
            }
        }


        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (normal4 != null)
        {
            var prevStateN = _Normalpreview3;
            _Normalpreview4 = AssetPreview.GetAssetPreview(normal4);
            if (_Normalpreview4 != null)
            {
                if (prevStateN == null)
                    Repaint();
                GUI.DrawTexture(GUILayoutUtility.GetRect(100, 100, 100, 100), _Normalpreview4, ScaleMode.ScaleToFit);
            }
        }

        GUILayout.EndHorizontal();
    }

  /*  void GameObjectSpawn()
    {
        EditorGUILayout.LabelField("Asset :");
        _object = (GameObject)EditorGUILayout.ObjectField(_object, typeof(GameObject), true);
        activar = EditorGUILayout.Toggle("Put Asset", activar);
        if (activar)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                var spawn = Instantiate(_object);
                spawn.transform.position = hit.point;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            activar = false;
        }
    }*/

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
    }

}

