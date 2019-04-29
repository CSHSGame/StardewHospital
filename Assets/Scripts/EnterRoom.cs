using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour {


    public HUDController HUD;
    public string roomName;

	// Use this for initialization
	void Start () {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HUD.RoomText.text = roomName;
        }
    }
}
