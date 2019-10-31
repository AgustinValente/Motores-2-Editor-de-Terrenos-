using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Proof))]
[ExecuteInEditMode]
public class ProofEditor : Editor
{
    Proof _target;
   
    private static Vector3 position;
    

    private void OnEnable()
    {
        _target = (Proof)target;
    }

    private void OnSceneGUI()
    {
        /*  if (Physics.Raycast(_target.ray, out _target.hit))
          {
              Handles.color = Color.red;
              Handles.DrawSolidDisc(_target.hit.transform.position, _target.hit.transform.forward, 15);
          }
          //  Handles.color = Color.blue;
          // Handles.DrawSolidDisc(Camera.current.WorldToScreenPoint(Input.mousePosition),Vector3.forward , 15);*/
        /*  Vector3 mousePosition = Event.current.mousePosition;
          Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
          mousePosition = ray.origin;
          Handles.DrawLine(_target.transform.position + Vector3.up, mousePosition);
          Handles.color = Color.red;
          Handles.DrawSolidDisc(mousePosition,_target.transform.forward, 5);*/

        Ray mousePosition;
        mousePosition = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        SceneView.RepaintAll();
        RaycastHit hit;
        if (Physics.Raycast(mousePosition, out hit))
        {
            Handles.color = Color.red;
            Handles.DrawSolidDisc(hit.point, -hit.transform.up, 10);
            HandleUtility.Repaint();
        }
        HandleUtility.Repaint();
    }
    
}
