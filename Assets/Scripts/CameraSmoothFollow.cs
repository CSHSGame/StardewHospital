using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.25f;
    public Vector3 Offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + Offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
}
