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

        target = EditorGUILayout.ObjectField(target, typeof(GameObject), false);

        EditorGUILayout.LabelField("Select Prefab From List: ");
        if (target == null)
        {
            throw new System.Exception("EDITOR DE PREFABS VACIO. SELECCIONE UN PREFAB");
        }


        if (target != null)
        {
               float posX = Selection.activeGameObject.GetComponent<Transform>().transform.position.x;
               float posY = Selection.activeGameObject.GetComponent<Transform>().transform.position.y;
               float posZ = Selection.activeGameObject.GetComponent<Transform>().transform.position.z;


            posXBool = EditorGUILayout.Toggle("Make to Front", posXBool);
                {
                    if (posXBool)
                    {
                    posXboolNegative = false;
                        posX++;

                    }
                    
                }
            posXboolNegative = EditorGUILayout.Toggle("Make to Back", posXboolNegative);
             {
                if (posXboolNegative)
                {
                    posXBool = false;
                    posX--;
                }

             }

            posYBool = EditorGUILayout.Toggle("Make to UP!", posYBool);
            {
                if (posYBool)
                {
                    posYboolNegative = false;
                    posY++;

                }
            }
            posYboolNegative = EditorGUILayout.Toggle("Make to Down !", posYboolNegative);
            {
                if (posYboolNegative)
                {
                    posYBool = false;
                    posY--;

                }
            }

            posZBool = EditorGUILayout.Toggle("Make to Left <", posZBool);
            {
                if (posZBool)
                {
                    posZboolNegative = false;
                    posZ++;

                }
            }
            posZboolNegative = EditorGUILayout.Toggle("Make to Right >", posZboolNegative);
            {
                if (posZboolNegative)
                {
                    posZBool = false;
                    posZ--;

                }
            }

            Quaternion rotation = new Quaternion(0f, 0f, 0f,0f);
                Vector3 position = new Vector3(posX, posY, posZ);

            if (GUILayout.Button("Spawn Prefab"))
            {

                Selection.activeObject = Instantiate(target, position, rotation);

            }


        }

    }

}
