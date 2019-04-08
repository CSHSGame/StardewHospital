using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Camera myCam;
    public int cullMask;
    public void OnDrawGizmos()
    {
        if(myCam != null)
        {
            cullMask = myCam.cullingMask;
            Gizmos.color = Color.black;
            float height = 2f * myCam.orthographicSize;
            float width = height * myCam.aspect;
            Gizmos.DrawWireCube(transform.position, new Vector3(width, 1, height));
            Gizmos.DrawWireCube(transform.position, new Vector3(width -.01f, 1, height - .01f));
            Gizmos.DrawWireCube(transform.position, new Vector3(width - .02f, 1, height - .02f));
            Gizmos.DrawWireCube(transform.position, new Vector3(width - .03f, 1, height - .03f));


        }

    }

}
