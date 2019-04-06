using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Waypoints)), CanEditMultipleObjects]
public class WayPointsBaker : Editor
{
    public override void OnInspectorGUI()
    {
        Waypoints myScript = (Waypoints)target;
        if(myScript.Paths!= null )
        {
            GUILayout.BeginHorizontal();
            if (myScript.Paths.Count > 1)
            {
                if (GUILayout.Button("remove path"))
                {
                    myScript.Paths.RemoveAt(myScript.pathindex);
                }

                if (GUILayout.Button("<"))
                {
                    Undo.RecordObject(myScript, "yo yo yo");

                    if (myScript.pathindex >= 1)
                    {
                        myScript.pathindex--;

                    }
                    else
                    {
                        myScript.pathindex = myScript.Paths.Count - 1;
                    }

                    SceneView.RepaintAll();
                }
                if (GUILayout.Button(">"))
                {
                    Undo.RecordObject(myScript, "yo yo yo");

                    if (myScript.pathindex < myScript.Paths.Count-1)
                    {
                        myScript.pathindex++;

                    }
                    else
                    {
                        myScript.pathindex = 0;
                    }
                    SceneView.RepaintAll();
                }
            }
            if (GUILayout.Button("add new path"))
            {
                myScript.Paths.Add(new pointsVector3(" ", myScript.transform.position + Vector3.forward));
                myScript.pathindex = myScript.Paths.Count - 1;
            }
          
            GUILayout.EndHorizontal();
            GUILayout.Label("Path Name");
            if(myScript.pathindex >= 0 && myScript.pathindex < myScript.Paths.Count)
            {
                GUILayout.BeginHorizontal();
                myScript.Paths[myScript.pathindex] = myScript.Paths[myScript.pathindex].setName( EditorGUILayout.TextField(myScript.Paths[myScript.pathindex].Name));
                GUILayout.EndHorizontal();
            }
            

        }

        DrawDefaultInspector();

        
        if (myScript.data != null)
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Bake Data"))
            {
                myScript.BakeData();
            }
            if (GUILayout.Button("load Data"))
            {
                myScript.loadData();
            }
            GUILayout.EndHorizontal();
        }
      





    }
    protected virtual void OnSceneGUI()
    {
        Waypoints myScript = (Waypoints)target;
      

        if (myScript.pathindex > -1 && myScript.pathindex < myScript.Paths.Count)
        {

            for (int i = 0; i < myScript.Paths[myScript.pathindex].location.Count; i++)
            {
                EditorGUI.BeginChangeCheck();

                Vector3 newTargetPosition = Handles.PositionHandle(myScript.Paths[myScript.pathindex].location[i], Quaternion.identity);
                if(i == 0)
                {
                   // Handles.DrawLine(myScript.transform.position, myScript.Paths[myScript.pathindex].location[i]);
                }
                else
                {
                    Handles.ArrowHandleCap(
                        0,
                        (myScript.Paths[myScript.pathindex].location[i-1]),
                         Quaternion.LookRotation(myScript.Paths[myScript.pathindex].location[i] - myScript.Paths[myScript.pathindex].location[i-1]), 
                        .9f,
                        EventType.Repaint);
                    Handles.DrawLine(myScript.Paths[myScript.pathindex].location[i-1], myScript.Paths[myScript.pathindex].location[i]);
                    
                }
                //if last point
                if(i == myScript.Paths[myScript.pathindex].location.Count - 1)
                {
                    Vector3 pos = myScript.Paths[myScript.pathindex].location[i];
                    pos = new Vector3(pos.x-0.5f, pos.y, pos.z + .25f);
                    //EditorGUI.BeginChangeCheck();

                    if (Handles.Button(pos, Quaternion.Euler(90,0,0), .25f, .25f, Handles.RectangleHandleCap))
                    {

                        Debug.Log("The button was pressed!");
                        Undo.RecordObject(myScript, "yo yo yo");

                        Vector3 newPos = myScript.Paths[myScript.pathindex].location[i];
                        if(i != 0)
                        {
                            myScript.Paths[myScript.pathindex].location.Add(newPos + (newPos - myScript.Paths[myScript.pathindex].location[i - 1]).normalized);

                        }
                        else
                        {
                            myScript.Paths[myScript.pathindex].location.Add(newPos + (newPos - myScript.transform.position).normalized);

                        }
                    }
                 
                    pos = myScript.Paths[myScript.pathindex].location[i];
                    pos = new Vector3(pos.x - 0.5f, pos.y, pos.z -.25f);
                    if(myScript.Paths[myScript.pathindex].location.Count >= 2)//cant remove last 2 poitns
                    {
                        if (Handles.Button(pos, Quaternion.Euler(90, 0, 0), .25f, .25f, Handles.RectangleHandleCap))
                        {
                            

                            //  Debug.Log("The button was pressed!");

                            myScript.Paths[myScript.pathindex].location.RemoveAt(i);
                        }
                    }
                }

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(myScript, "Change Look At Target Position");
                    myScript.Paths[myScript.pathindex].location[i] = newTargetPosition;
                    //  example.Update();
                }
              
            }
        }
      
      
    }

}