using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterRoomUI : MonoBehaviour {

    public float lerpTime = 1f;
    public float stayTime = 1f;
    public float lerpOutTime = 1f;
    public float currentLerpTime;
    public float currentStayTime;
    public float currentLerpOutTime;
    public bool Lerp = true;
    public LerpUtility.lerpMode lerpMode;
    public Vector3 startLoc;
    public Vector3 endLoc;
    public string roomName;

    // Use this for initialization
    void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
        LerpRoomName(roomName);

    }

    public void LerpRoomName(string roomname)
    {
        if (Lerp)
        {
            GetComponentInChildren<Text>().text = roomname;
            currentLerpTime += Time.deltaTime;

            float perc = LerpUtility.Lerp(currentLerpTime, lerpTime, lerpMode);

            transform.position = Vector3.Lerp(startLoc, endLoc, perc);


            if (currentLerpTime > lerpTime)
            {
                currentStayTime += Time.deltaTime;
            }

            if (currentStayTime > stayTime)
            {
                currentLerpOutTime += Time.deltaTime;
                float lerpOutPerc = LerpUtility.Lerp(currentLerpOutTime, lerpOutTime, lerpMode);
                transform.position = Vector3.Lerp(endLoc, startLoc, lerpOutPerc);
            }

            if (currentLerpOutTime > lerpOutTime)
            {
                currentLerpTime = 0;
                currentStayTime = 0;
                currentLerpOutTime = 0;
                Lerp = false;
            }
        }
    }
}
