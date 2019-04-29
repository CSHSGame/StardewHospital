using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicMode : MonoBehaviour
{

    // Use this for initialization
    public GameObject panel1;
    public GameObject panel2;


    public void TurnON()
    {
        if (!panel1.activeSelf)
        {
            panel1.SetActive(true);
            panel2.SetActive(true);
        }
      

    }
    public void TurnOFF()
    {
        if (panel1.activeSelf)
        {
            panel1.SetActive(false);
            panel2.SetActive(false);
        }

    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
