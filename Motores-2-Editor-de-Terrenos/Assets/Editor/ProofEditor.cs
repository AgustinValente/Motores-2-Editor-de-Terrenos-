using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Proof))]
[ExecuteInEditMode]
public class ProofEditor : Editor
{
   
    Proof _target;   
    Ray mousePosition;
    RaycastHit hit;
    private string[] toolbarOptions = new string[] {"Ninguno","Ciculo", "Cuadrado"};
    int _currentToolbarSelection;
    private void OnEnable()
    {
        _target = (Proof)target;
    }

 

    private void OnSceneGUI()
    {
        Handles.BeginGUI();
        var v = EditorWindow.GetWindow<SceneView>().camera.pixelRect;
        GUILayout.BeginArea(new Rect(20, 20, 300, 175));
        _target.radius = EditorGUILayout.FloatField("Radio", _target.radius);

        _target.opacity = EditorGUILayout.Slider("opacidad", _target.opacity,0.1f,1);

        _currentToolbarSelection = GUILayout.Toolbar(_currentToolbarSelection, toolbarOptions);
        GUILayout.EndArea();
        Handles.EndGUI();
        if (_currentToolbarSelection == 1)
        {
            SphereHandles();
        }
        if (_currentToolbarSelection == 2)
        {
            QuadHandles();
        }

    }

    void SphereHandles()
    {
        mousePosition = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        SceneView.RepaintAll();
        if (Physics.Raycast(mousePosition, out hit))
        {
            Handles.color = new Color(1,0,0, _target.opacity);
            Handles.DrawSolidDisc(hit.point, -hit.transform.up, _target.radius);
            HandleUtility.Repaint();
        }
        HandleUtility.Repaint();
    }
    void QuadHandles()
    {
        var verts = new Vector3[]
        {
            new Vector3(hit.point.x -_target.radius,hit.point.y,hit.point.z -_target.radius),
            new Vector3(hit.point.x -_target.radius,hit.point.y,hit.point.z +_target.radius),
            new Vector3(hit.point.x +_target.radius,hit.point.y,hit.point.z +_target.radius),
            new Vector3(hit.point.x +_target.radius,hit.point.y,hit.point.z -_target.radius)
        };
        mousePosition = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        SceneView.RepaintAll();
        if (Physics.Raycast(mousePosition, out hit))
        {
            Handles.color = Color.red;
            // Handles.DrawSolidDisc(hit.point, -hit.transform.up, _target.radius);
           Handles.DrawSolidRectangleWithOutline(verts, new Color(1, 0, 0, _target.opacity),new Color(1, 0, 0, _target.opacity));
            HandleUtility.Repaint();
        }
        HandleUtility.Repaint();
    }

}
