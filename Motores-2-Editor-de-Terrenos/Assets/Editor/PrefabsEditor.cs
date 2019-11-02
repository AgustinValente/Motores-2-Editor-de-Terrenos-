using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEditor;

public class PrefabsEditor : EditorWindow
{
    public Object target;
    public GameObject prefab;
    public bool posXBool;
    public bool posXboolNegative;
    public bool posYBool;
    public bool posYboolNegative;
    public bool posZBool;
    public bool posZboolNegative;


    [MenuItem("Prefab Maker/PrefabEditor")]

    public static void OpenWindow()
    {

        var w = GetWindow<PrefabsEditor>();
        w.Show();
    }

    private void OnGUI()
    {
        /* EditorGUILayout.LabelField("Select Prefab or a GameObject: ");
         target = EditorGUILayout.ObjectField(target, typeof(GameObject), true);*/

        EditorGUILayout.LabelField("Select GameObject from the Scene: ");
        /*   if (target == null)
           {
               throw new System.Exception("EDITOR DE PREFABS VACIO. SELECCIONE UN PREFAB");
           }*/



        if (Selection.activeGameObject != null)
        {
            float posX = Selection.activeGameObject.GetComponent<Transform>().transform.position.x;
            float posY = Selection.activeGameObject.GetComponent<Transform>().transform.position.y;
            float posZ = Selection.activeGameObject.GetComponent<Transform>().transform.position.z;


            posXBool = EditorGUILayout.Toggle("Make to Front", posXBool);
            {
                if (posXBool)
                {
                    posXboolNegative = false;
                    posX = Selection.activeGameObject.transform.position.x + Selection.activeGameObject.transform.localScale.x;

                }

            }
            posXboolNegative = EditorGUILayout.Toggle("Make to Back", posXboolNegative);
            {
                if (posXboolNegative)
                {
                    posXBool = false;
                    posX = Selection.activeGameObject.transform.position.x - Selection.activeGameObject.transform.localScale.x;
                }

            }

            posYBool = EditorGUILayout.Toggle("Make to UP!", posYBool);
            {
                if (posYBool)
                {
                    posYboolNegative = false;
                    posY = Selection.activeGameObject.transform.position.y + Selection.activeGameObject.transform.localScale.y;

                }
            }
            posYboolNegative = EditorGUILayout.Toggle("Make to Down !", posYboolNegative);
            {
                if (posYboolNegative)
                {
                    posYBool = false;
                    posY = Selection.activeGameObject.transform.position.y - Selection.activeGameObject.transform.localScale.y;

                }
            }

            posZBool = EditorGUILayout.Toggle("Make to Left <", posZBool);
            {
                if (posZBool)
                {
                    posZboolNegative = false;
                    posZ = Selection.activeGameObject.transform.position.z + Selection.activeGameObject.transform.localScale.z;

                }
            }
            posZboolNegative = EditorGUILayout.Toggle("Make to Right >", posZboolNegative);
            {
                if (posZboolNegative)
                {
                    posZBool = false;
                    posZ = Selection.activeGameObject.transform.position.z - Selection.activeGameObject.transform.localScale.z;

                }
            }

            Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
            Vector3 position = new Vector3(posX, posY, posZ);

            if (GUILayout.Button("Spawn Prefab"))
            {

                Selection.activeObject = Instantiate(Selection.activeGameObject, position, rotation);

            }




        }

    }

}