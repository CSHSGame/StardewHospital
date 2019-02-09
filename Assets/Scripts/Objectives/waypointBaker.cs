using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Waypoints)), CanEditMultipleObjects]
public class WayPointsBaker : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Waypoints myScript = (Waypoints)target;

        if (myScript.data != null)
        {
            if (GUILayout.Button("Bake Data"))
            {
                myScript.BakeData();
            }
        }
    
       


    }
    protected virtual void OnSceneGUI()
    {
        Waypoints myScript = (Waypoints)target;
        EditorGUI.BeginChangeCheck();
        Vector3 newTargetPosition = Handles.PositionHandle(myScript.targetPosition, Quaternion.identity);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(myScript, "Change Look At Target Position");
            myScript.targetPosition = newTargetPosition;
            //  example.Update();
        }
    }

}