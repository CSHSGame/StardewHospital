using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterRoomUI : MonoBehaviour {

    public float lerpTime = 1f;
    public float stayTime = 1f;
    float currentLerpTime;
    float currentStayTime;
    public bool Lerp = true;
    public LerpUtility.lerpMode lerpMode;
    public Vector3 startLoc;
    public Vector3 endLoc;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Lerp)
        {
            currentLerpTime += Time.deltaTime;

            float perc = LerpUtility.Lerp(currentLerpTime, lerpTime, lerpMode);
            
            transform.position = Vector3.Lerp(startLoc, endLoc, perc);


            if (currentLerpTime > lerpTime)
            {
                currentStayTime += Time.deltaTime;
                float stayperc = LerpUtility.Lerp(currentStayTime, stayTime, lerpMode);
                transform.position = Vector3.Lerp(endLoc, startLoc, stayperc);
                
            }

            if(currentStayTime > stayTime)
            {
                currentLerpTime = 0;
                currentStayTime = 0;
                Lerp = false;
            }
        }
    }
}
