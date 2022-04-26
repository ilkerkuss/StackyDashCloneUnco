using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlatformEditor : EditorWindow
{
    public float XValue;
    public float YValue;
    public float ZValue;

    public int Count = 5;

    public GameObject Parent;

    public GameObject SpawnObject;


    public string[] tagList = { "ObstacleParent","PickParent","BridgeParent"};
    public int SelGridInt = 0;



    [MenuItem("Window/PlatformEditor")]
    public static void ShowWindow()
    {
        GetWindow<PlatformEditor>("PlatformEditor");
    }

    private void OnGUI()
    {

        SpawnObject = EditorGUILayout.ObjectField(SpawnObject, typeof(GameObject), false) as GameObject;

        GUILayout.Label(" Select Object From Scene or Hierarchy then Choose ParentObject type for Parent ! ",EditorStyles.boldLabel);
        SelGridInt = GUILayout.SelectionGrid(SelGridInt,tagList,1);

        GUILayout.Label("X Increase Value",EditorStyles.boldLabel);
        XValue = EditorGUILayout.FloatField(XValue);

        GUILayout.Label("Y Increase Value",EditorStyles.boldLabel);
        YValue = EditorGUILayout.FloatField(YValue);

        GUILayout.Label("Z Increase Value",EditorStyles.boldLabel);
        ZValue = EditorGUILayout.FloatField(ZValue);

        GUILayout.Label("Count Amount:", EditorStyles.boldLabel);
        Count = EditorGUILayout.IntField(Count);

        Parent = GameObject.FindGameObjectWithTag(tagList[SelGridInt]);

        if (GUILayout.Button("Create"))
        {
            if (SpawnObject != null)
            {
                CreateObjectInParent(SpawnObject);
            }
          
        }

        else if (GUILayout.Button("Create Relatively"))
        {
            if (SpawnObject !=null)
            {
                CreateRelatively(SpawnObject);
            }
            
        }
 
    }

    public void CreateObjectInParent(GameObject SpawnObj)
    {
        // I created first 5 level with this code line but i changed it with bottom code because of prefab - prefab clone situation
        /*
        foreach (GameObject obj in Selection.gameObjects)
        {
            for (int i = 0; i < Count; i++)
            {
                GameObject go = Instantiate(obj);
                Vector3 pos = obj.transform.position;

                pos.x += XValue * (i + 1);
                pos.y += YValue * (i + 1);
                pos.z += ZValue * (i + 1);

                go.transform.position = pos;
                go.transform.SetParent(Parent.transform);

            }
            */


        string prefabPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(SpawnObj);

        foreach (GameObject obj in Selection.gameObjects)
        {
            
            //Get prefab object from path
            Object prefab = AssetDatabase.LoadAssetAtPath(prefabPath, typeof(Object));
            //Instantiate the prefab in the scene, as a sibling of current gameObject
            var go= PrefabUtility.InstantiatePrefab(prefab, Parent.transform)as GameObject;

           

            go.transform.position = obj.transform.position;
            go.transform.SetParent(Parent.transform);

            obj.SetActive(false);

        }
    }

    public void CreateRelatively(GameObject SpawnObj)
    {
        string prefabPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(SpawnObj);

        foreach (GameObject obj in Selection.gameObjects)
        {
            for (int i = 0; i < Count; i++)
            {
                //Get prefab object from path
                Object prefab = AssetDatabase.LoadAssetAtPath(prefabPath, typeof(Object));
                //Instantiate the prefab in the scene, as a sibling of current gameObject
                var go = PrefabUtility.InstantiatePrefab(prefab, Parent.transform) as GameObject;

                Vector3 pos = obj.transform.position;

                pos.x += XValue * (i + 1);
                pos.y += YValue * (i + 1);
                pos.z += ZValue * (i + 1);

                go.transform.position = pos;
                go.transform.SetParent(Parent.transform);

            }
        }
    }
}


   



