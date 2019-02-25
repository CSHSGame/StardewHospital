using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanner : MonoBehaviour {


    public Camera Cam;

	// Use this for initialization
	void Start () {
        StartCoroutine(PanCamera1(15.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator PanCamera1(float time)
    {
        Cam.orthographicSize = 7.0f;
        Vector3 CameraStartPos = new Vector3(-19, 10, 3);
        Vector3 CameraEndPos = new Vector3(30, 10, 3);
        float panTime = 0.0f;

        do
        {
            this.transform.position = Vector3.Lerp(CameraStartPos, CameraEndPos, panTime/time);

            panTime += Time.deltaTime;

            yield return null;

        } while (panTime <= time);

        panTime = 0.0f;

        StartCoroutine(PanCamera2(15.0f));
    }

    IEnumerator PanCamera2(float time)
    {
        Cam.orthographicSize = 10.0f;
        Vector3 CameraStartPos = new Vector3(36, 10, 44);
        Vector3 CameraEndPos = new Vector3(-25, 10, 44);
        float panTime = 0.0f;

        do
        {
            this.transform.position = Vector3.Lerp(CameraStartPos, CameraEndPos, panTime / time);

            panTime += Time.deltaTime;

            yield return null;

        } while (panTime <= time);

        panTime = 0.0f;

        StartCoroutine(PanCamera3(15.0f));
    }
    IEnumerator PanCamera3(float time)
    {
        Cam.orthographicSize = 10.0f;
        Vector3 CameraStartPos = new Vector3(4.5f, 10, 6);
        Vector3 CameraEndPos = new Vector3(4.5f, 10, 44);
        float panTime = 0.0f;

        do
        {
            this.transform.position = Vector3.Lerp(CameraStartPos, CameraEndPos, panTime / time);

            panTime += Time.deltaTime;

            yield return null;

        } while (panTime <= time);

        panTime = 0.0f;

        StartCoroutine(PanCamera1(15.0f));
    }
}
