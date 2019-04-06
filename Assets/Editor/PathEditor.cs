using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathTest))]
public class ObjectBuilderEditor2 : Editor
{
    bool JustPressed = false;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PathTest myScript = (PathTest)target;

        if (myScript.lineRenderer != null)
        {
            if (GUILayout.Button("update line"))
            {
                myScript.updateLine();
            }
        }
        else
        {
            if (GUILayout.Button("Build line"))
            {
                myScript.setupLine();
            }
        }

    }
    public void OnSceneGUI()
    {
        PathTest myScript = (PathTest)target;
        Event e = Event.current;
        switch (e.type)
        {
            case EventType.KeyDown:
                if (e.keyCode == KeyCode.W && JustPressed == false)
                {
                    Selection.activeGameObject = myScript.createNextPoint(Selection.activeGameObject);
                    JustPressed = true;
                }
                break;
            case EventType.KeyUp:
                if (e.keyCode == KeyCode.W && JustPressed == true)
                {
                    JustPressed = false;

                }
                break;

        }


    }
}