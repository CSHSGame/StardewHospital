using UnityEditor;
using UnityEngine;

using Yarn.Unity.Example;
[CustomEditor(typeof(NPC))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        NPC myScript = (NPC)target;

        if (myScript.data != null)
        {
            if (GUILayout.Button("Bake Data"))
            {
                myScript.BakeData();
                //PrefabUtility.GetCorrespondingObjectFromSource(myScript.gameObject) as Transform
            }
        }
        if (myScript.data != null)
        {
            if (GUILayout.Button("Load Data"))
            {
                myScript.LoadData();
            }
        }



    }
}
