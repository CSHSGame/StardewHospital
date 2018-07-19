using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour {


    public enum NPC
    {
        None,
        NPC1,
        NPC2,
        NPC3,
        NPC4,
    }

    public NPC thisNPC;

    public GameObject NPC1TextBox;
    public GameObject NPC2TextBox;
    public GameObject NPC3TextBox;
    public GameObject NPC4TextBox;

    private bool textOn = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (textOn == true)
        {
            textOn = false;
            NPC1TextBox.SetActive(false);
            NPC2TextBox.SetActive(false);
            NPC3TextBox.SetActive(false);
            NPC4TextBox.SetActive(false);
        }
        else
        {
            textOn = true;
            if (thisNPC == NPC.NPC1)
            {
                NPC1TextBox.SetActive(true);
            }
            else if (thisNPC == NPC.NPC2)
            {
                NPC2TextBox.SetActive(true);
            }
            else if (thisNPC == NPC.NPC3)
            {
                NPC3TextBox.SetActive(true);
            }
            else if (thisNPC == NPC.NPC4)
            {
                NPC4TextBox.SetActive(true);
            }
        }
    }
}
