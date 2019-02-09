using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour {


    public EnterRoomUI roomUI;
    public string roomName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            roomUI.roomName = roomName;
            roomUI.currentLerpTime = 0.0f;
            roomUI.currentStayTime = 0.0f;
            roomUI.currentLerpOutTime = 0.0f;
            roomUI.Lerp = true;
           
        }
    }
}
